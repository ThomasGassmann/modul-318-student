namespace SwissTransport.UI
{
    using SwissTransport.DataAccess;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.Common;
    using SwissTransport.UI.Common.Interfaces;
    using SwissTransport.UI.Validation;
    using SwissTransport.UI.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class SwissTransportMainForm : Form
    {
        private readonly IQueryService queryService = new TransportationQueryService();

        private readonly IActionHandler actionHandler;

        private readonly ILocationQueryService locationQueryService = new LocationQueryService();

        private readonly ILocatableStationService locatableStationService;

        private readonly static object lockObj = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="SwissTransportMainForm"/> class.
        /// </summary>
        public SwissTransportMainForm()
        {
            this.InitializeComponent();
            this.lvStations.Columns[0].Width = this.lvStations.Width - 10;
            this.actionHandler = new ActionHandler(this);
            this.locatableStationService = new LocatableStationService(
                this.locationQueryService,
                this.queryService);
        }

        private void ShowExtendedOptions_CheckedChanged(object sender, System.EventArgs e) =>
            this.gbExtendedOptions.Visible = !this.gbExtendedOptions.Visible;

        /// <summary>
        /// Loads the stations into the <see cref="ComboBox"/> calling the event. 
        /// The operation will be aborted, if the caller is no <see cref="ComboBox"/>.
        /// Async void is valid in this case, because Event Handler in Win Forms need to
        /// be void instead ot Task.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void LoadStationCombobox(object sender, EventArgs e)
        {
            if (sender is ComboBox cb)
            {
                if (cb.Text == string.Empty)
                {
                    /// Only load current location, if the <see cref="ComboBox"/> is empty
                    await this.actionHandler.HandleFunc(async () => await this.LoadCurrentLocationIntoComboboxes(cb));
                    return;
                }

                var comboBoxText = cb.Text;
                var selectionStart = cb.SelectionStart;
                var length = cb.SelectionLength;
                cb.DataSource = new List<string> { "Resultate werden geholt..." };
                var stations = await Task.Run(() =>
                    this.actionHandler.HandleFunc(() =>
                        this.queryService.GetStations(comboBoxText)));
                if (stations == default(StationCollection))
                {
                    return;
                }

                var viewModels = await Task.Run(() => this.actionHandler.HandleFunc(async () =>
                {
                    var selectedViewModels = stations.StationList
                        .MapCollection<TransportStation, ComboboxItemViewModel<TransportStation>>().ToList();
                    var currentLocation = await this.actionHandler.HandleFunc(async () => await this.GetCurrentLocationComboboxViewModel());
                    if (currentLocation != null)
                    {
                        selectedViewModels.Add(currentLocation);
                    }

                    return selectedViewModels;
                }));

                cb.DataSource = viewModels;
                cb.Text = comboBoxText;
                cb.SelectionStart = selectionStart;
                cb.SelectionLength = length;
            }
        }

        private void MoreStationBoardOptions_CheckedChanged(object sender, EventArgs e) =>
            this.gbMoreStationOptions.Visible = !this.gbMoreStationOptions.Visible;

        private async void SearchConnections_Click(object sender, EventArgs e)
        {
            if (this.AreValidConnectionStationsSelected())
            {
                var button = sender as Button;
                button.Enabled = false;
                this.lvConnections.Items.Clear();
                using (new ProgressBarRunner(this.progressBar, this.ValidateConnectionSearchButton))
                {
                    var fromStationViewModel = (ComboboxItemViewModel<TransportStation>)this.cbDeparture.SelectedItem;
                    var toStationViewModel = (ComboboxItemViewModel<TransportStation>)this.cbArrival.SelectedItem;
                    var constructedDateTime = this.cbShowExtendedOptions.Checked
                        ? this.ConstructDateTime(this.dtpConnectionSearchDate, this.dtpConnectionSearchTime)
                        : DateTime.Now;
                    var fromStationId = fromStationViewModel.Value.Id;
                    var toStationId = toStationViewModel.Value.Id;
                    var isArrivalTime = this.rbArrivalTime.Checked;
                    var connections = await Task.Run(() =>
                        this.actionHandler.HandleFunc(() =>
                            this.queryService.GetConnections(fromStationId, toStationId, constructedDateTime, isArrivalTime)));
                    if (connections == null)
                    {
                        return;
                    }

                    var viewModels = connections.ConnectionList
                        .MapCollection<TransportConnection, ListViewItem>();
                    this.lvConnections.Items.AddRange(viewModels.ToArray());
                }
            }
        }

        private async void StationSearch_Click(object sender, EventArgs e)
        {
            this.btStationSearch.Enabled = false;
            using (new ProgressBarRunner(this.progressBar, this.ValidateSearchStationButton))
            {
                this.lvStations.Items.Clear();
                var textBoxValue = this.tbSearchStation.Text;
                var stationResult = await Task.Run(() =>
                    this.actionHandler.HandleFunc(
                        () => this.queryService.GetStations(textBoxValue)));
                if (stationResult == null)
                {
                    return;
                }

                var stations = this.actionHandler.HandleFunc(
                    () => stationResult.StationList.MapCollection<TransportStation, ListViewItem>().ToArray(),
                    exception => MessageBox.Show("Die Daten der API scheinen invalid zu sein. Bitte überprüfen Sie ihre Internetverbindung."));
                this.lvStations.Items.AddRange(stations);
            }
        }

        private async void SearchStationBoard_Click(object sender, EventArgs e)
        {
            if (this.cbSearchStationBoard.SelectedItem != null &&
                this.IsValidStationBoardStation())
            {
                this.lvStationBoard.Items.Clear();
                this.btSearchStationBoard.Enabled = false;
                using (new ProgressBarRunner(this.progressBar, this.ValidateStationBoardDisplayButton))
                {
                    var station = (ComboboxItemViewModel<TransportStation>)this.cbSearchStationBoard.SelectedItem;
                    var stationId = station.Value.Id;
                    var constructedDateTime = this.cbMoreStationBoardOptions.Checked
                        ? this.ConstructDateTime(this.dtpStationBoardDate, this.dtpStationBoardTime)
                        : DateTime.Now;
                    var stationBoard = await Task.Run(() =>
                        this.actionHandler.HandleFunc(() =>
                            this.queryService.GetStationBoard(stationId, constructedDateTime)));
                    if (stationBoard == null)
                    {
                        return;
                    }

                    var listViewItems = await Task.Run(() => this.actionHandler.HandleFunc(() =>
                        stationBoard.Map<StationBoardRoot, IEnumerable<ListViewItem>>().ToArray()));
                    this.lvStationBoard.Items.AddRange(listViewItems);
                }
            }
        }

        private DateTime ConstructDateTime(DateTimePicker datePicker, DateTimePicker timePicker) =>
            datePicker.Value.Date
                        .AddHours(timePicker.Value.Hour)
                        .AddMinutes(timePicker.Value.Minute);

        private void ConnectionButtonValidation(object sender, EventArgs e) =>
            this.ValidateConnectionSearchButton();

        private void StationBoardDisplayButtonValidation(object sender, EventArgs e) =>
            this.ValidateStationBoardDisplayButton();

        private bool IsValidStationBoardStation() =>
            ComboboxValidater.ContainValidLocations(this.cbSearchStationBoard);

        private bool AreValidConnectionStationsSelected() =>
            ComboboxValidater.ContainValidLocations(this.cbArrival, this.cbDeparture);
        
        private void ValidateStationBoardDisplayButton() =>
            this.btSearchStationBoard.Enabled = this.IsValidStationBoardStation() && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        private void ValidateConnectionSearchButton() =>
            this.btSearchConnections.Enabled = this.AreValidConnectionStationsSelected() && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        private void ValidateSearchStationButton() =>
            this.btStationSearch.Enabled = this.tbSearchStation.Text != string.Empty && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        private void SearchStation_TextChanged(object sender, EventArgs e) =>
            this.ValidateSearchStationButton();

        private void Stations_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvStations.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListView lv && lv.SelectedItems.Count == 1)
            {
                var selectedItem = lv.SelectedItems[0];
                var stationTag = (TransportStation)selectedItem.Tag;
                this.tbStationLongitude.Text = stationTag.Coordinate.YCoordinate.ToString();
                this.tbStationLatitude.Text = stationTag.Coordinate.XCoordinate.ToString();
                var gmapsUrl = $"https://www.google.com/maps/preview/@{this.tbStationLatitude.Text},{this.tbStationLongitude.Text},19z";
                this.wbStations.Navigate(gmapsUrl);
            }
        }

        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbSelectedTab.Text = ((TabControl)sender).SelectedTab.Text;
            await this.LoadCurrentLocationIntoComboboxes(this.cbDeparture, this.cbSearchStationBoard);
        }


        private async Task<ComboboxItemViewModel<TransportStation>> GetCurrentLocationComboboxViewModel()
        {
            var closeLocation = await Task.Run(() => this.actionHandler.HandleFunc(
                () => this.locatableStationService.GetClosestStation(),
                exception => { }));
            if (closeLocation != null)
            {
                var viewModel = new ComboboxItemViewModel<TransportStation>(closeLocation, x => $"Aktueller Standort: {x.Name}");
                return viewModel;
            }

            return null;
        }

        private async Task LoadCurrentLocationIntoComboboxes(params ComboBox[] comboBoxesToApply)
        {
            var closeLocation = await this.GetCurrentLocationComboboxViewModel();
            if (closeLocation != null)
            {
                foreach (var comboBox in comboBoxesToApply)
                {
                    comboBox.DataSource = new List<ComboboxItemViewModel<TransportStation>> { closeLocation };
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        private async void SwissTransportMainForm_Load(object sender, EventArgs e) =>
            await this.LoadCurrentLocationIntoComboboxes(this.cbDeparture, this.cbSearchStationBoard);
    }
}
