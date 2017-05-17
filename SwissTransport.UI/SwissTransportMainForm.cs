namespace SwissTransport.UI
{
    using SwissTransport.DataAccess;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using SwissTransport.UI.ActionHandlers;
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

        private readonly IActionHandler actionHandler = new ActionHandler();

        private readonly static object lockObj = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="SwissTransportMainForm"/> class.
        /// </summary>
        public SwissTransportMainForm()
        {
            this.InitializeComponent();
            this.lvStations.Columns[0].Width = this.lvStations.Width - 10;
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
                    /// No need for execution, if the <see cref="ComboBox"/> is empty
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

                var selectedViewModels = stations.StationList
                    .MapCollection<TransportStation, ComboboxItemViewModel<TransportStation>>();
                cb.DataSource = selectedViewModels.ToArray();
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
                this.pbConnectionSearch.MarqueeAnimationSpeed = 100;
                this.pbConnectionSearch.Style = ProgressBarStyle.Marquee;
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
                var viewModels = connections.ConnectionList
                    .MapCollection<TransportConnection, ListViewItem>();
                this.lvConnections.Items.AddRange(viewModels.ToArray());
                this.pbConnectionSearch.Style = ProgressBarStyle.Blocks;
                this.ValidateConnectionSearchButton();
            }
        }

        private async void StationSearch_Click(object sender, EventArgs e)
        {
            this.pbStationSearch.Style = ProgressBarStyle.Marquee;
            this.lvStations.Items.Clear();
            var textBoxValue = this.tbSearchStation.Text;
            var stationResult = await Task.Run(() =>
                this.actionHandler.HandleFunc(() =>
                    this.queryService.GetStations(textBoxValue)));
            var stations = this.actionHandler.HandleFunc(
                () => stationResult.StationList.MapCollection<TransportStation, ListViewItem>().ToArray(),
                exception => MessageBox.Show("Die Daten der API scheinen invalid zu sein. Bitte überprüfen Sie ihre Internetverbindung."));
            this.lvStations.Items.AddRange(stations);
            this.pbStationSearch.Style = ProgressBarStyle.Blocks;
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
            this.btStationSearch.Enabled = this.IsValidStationBoardStation()
                ? true
                : false;

        private void ValidateConnectionSearchButton() =>
            this.btSearchConnections.Enabled = this.AreValidConnectionStationsSelected()
                ? true
                : false;

        private void SearchStation_TextChanged(object sender, EventArgs e)
        {
            this.btStationSearch.Enabled = false;
            if (this.tbSearchStation.Text != string.Empty)
            {
                this.btStationSearch.Enabled = true;
            }
        }

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

        private async void SearchStationBoard_Click(object sender, EventArgs e)
        {
            if (this.cbSearchStationBoard.SelectedItem != null &&
                this.IsValidStationBoardStation())
            {
                this.pbStationBoard.Style = ProgressBarStyle.Marquee;
                var station = (TransportStation)this.cbSearchStationBoard.SelectedItem;
                var stationId = station.Id;
                var constructedDateTime = this.cbMoreStationBoardOptions.Checked
                    ? this.ConstructDateTime(this.dtpConnectionSearchDate, this.dtpConnectionSearchTime)
                    : DateTime.Now;
                var stationBoard = await Task.Run(() =>
                    this.actionHandler.HandleFunc(() =>
                        this.queryService.GetStationBoard(stationId, constructedDateTime)));
                var listViewItems = this.actionHandler.HandleFunc(() =>
                    stationBoard.Map<StationBoardRoot, IEnumerable<ListViewItem>>().ToArray(),
                    exception => MessageBox.Show("Die Daten der API scheinen invalid zu sein. Bitte überprüfen Sie ihre Internetverbindung."));
                this.lvStationBoard.Items.AddRange(listViewItems);
                this.pbStationBoard.Style = ProgressBarStyle.Blocks;
            }
        }
    }
}
