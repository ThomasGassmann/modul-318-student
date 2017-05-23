namespace SwissTransport.UI.Forms
{
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.Common;
    using SwissTransport.UI.Validation;
    using SwissTransport.UI.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// The main UI form.
    /// </summary>
    public partial class SwissTransportMainForm : Form
    {
        /// <summary>
        /// Stores the service to get the transport data from the web API.
        /// </summary>
        private readonly IQueryService queryService = new TransportationQueryService();

        /// <summary>
        /// Stores the action handler to handle the actions and functions.
        /// </summary>
        private readonly IActionHandler actionHandler;

        /// <summary>
        /// Stores the service to get the current location via the IP address.
        /// </summary>
        private readonly ILocationQueryService locationQueryService = new LocationQueryService();

        /// <summary>
        /// Stores the service to get stations close the current user's location.
        /// </summary>
        private readonly ILocatableStationService locatableStationService;
    
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

        /// <summary>
        /// Toggles the visibility of the extended options group box.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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
                    // Only load current location, if the <see cref="ComboBox"/> is empty
                    await this.actionHandler.HandleFunc(async () => await this.LoadCurrentLocationIntoComboboxes(cb));
                    return;
                }

                var comboBoxText = cb.Text;
                var selectionStart = cb.SelectionStart;
                var length = cb.SelectionLength;
                cb.DataSource = new List<string> { "Resultate werden geholt..." };
                //// Get the stations.
                var stations = await Task.Run(() =>
                    this.actionHandler.HandleFunc(() =>
                        this.queryService.GetStations(comboBoxText)));
                if (stations == default(StationCollection))
                {
                    return;
                }

                //// Map the stations to their view models.
                var viewModels = await Task.Run(() => this.actionHandler.HandleFunc(async () =>
                {
                    var selectedViewModels = stations.StationList
                        .MapCollection<TransportStation, ComboboxItemViewModel<TransportStation>>().ToList();
                    //// Add the current location.
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

        /// <summary>
        /// Searches connections betweent the stations and loads them into the <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void SearchConnections_Click(object sender, EventArgs e)
        {
            // Only execute, if there are valid stations selected
            if (this.AreValidConnectionStationsSelected())
            {
                var button = sender as Button;
                button.Enabled = false;
                this.lvConnections.Items.Clear();
                using (new ProgressBarRunner(this.progressBar, this.ValidateConnectionSearchButton))
                {
                    var fromStationViewModel = (ComboboxItemViewModel<TransportStation>)this.cbDeparture.SelectedItem;
                    var toStationViewModel = (ComboboxItemViewModel<TransportStation>)this.cbArrival.SelectedItem;
                    //// Construct the time to get the connections at
                    var constructedDateTime = this.cbShowExtendedOptions.Checked
                        ? this.ConstructDateTime(this.dtpConnectionSearchDate, this.dtpConnectionSearchTime)
                        : DateTime.Now;
                    var fromStationId = fromStationViewModel.Value.Id;
                    var toStationId = toStationViewModel.Value.Id;
                    var isArrivalTime = this.rbArrivalTime.Checked;
                    //// Get the connections
                    var connections = await Task.Run(() =>
                        this.actionHandler.HandleFunc(() =>
                            this.queryService.GetConnections(fromStationId, toStationId, constructedDateTime, isArrivalTime)));
                    if (connections == null)
                    {
                        return;
                    }

                    //// Map the connections the their view models and load them into the list view.
                    var viewModels = connections.ConnectionList
                        .MapCollection<TransportConnection, ListViewItem>();
                    this.lvConnections.Items.AddRange(viewModels.ToArray());
                }
            }
        }

        /// <summary>
        /// Loads the stations into the list view to select a station to view its details.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void StationSearch_Click(object sender, EventArgs e)
        {
            this.btStationSearch.Enabled = false;
            using (new ProgressBarRunner(this.progressBar, this.ValidateSearchStationButton))
            {
                this.lvStations.Items.Clear();
                var textBoxValue = this.tbSearchStation.Text;
                //// Load the stations
                var stationResult = await Task.Run(() =>
                    this.actionHandler.HandleFunc(
                        () => this.queryService.GetStations(textBoxValue)));
                if (stationResult == null)
                {
                    return;
                }

                //// Get the view models and load them into the list view
                var stations = this.actionHandler.HandleFunc(
                    () => stationResult.StationList.MapCollection<TransportStation, ListViewItem>().ToArray(),
                    exception => MessageBox.Show(
                        "Die Daten der API scheinen invalid zu sein. Bitte überprüfen Sie ihre Internetverbindung.",
                        string.Empty,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error));
                if (stations != null)
                {
                    this.lvStations.Items.AddRange(stations);
                }
            }
        }

        /// <summary>
        /// Starts or stops the timer to auto-refresh the station board.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AutoRefreshStationBoard_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbAutoRefreshStationBoard.Checked)
            {
                this.timerStationBoard.Start();
            }
            else
            {
                this.timerStationBoard.Stop();
            }
        }

        /// <summary>
        /// Shows the <see cref="StationSelector"/> dialog and loads it into the given <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="comboBoxToLoadInto">The <see cref="ComboBox"/> to load the selected <see cref="TransportStation"/> into.</param>
        private void SearchStationDialog(ComboBox comboBoxToLoadInto)
        {
            using (var dialog = new StationSelector())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var viewModel = dialog.SelectedStation.Map<TransportStation, ComboboxItemViewModel<TransportStation>>();
                    comboBoxToLoadInto.DataSource = new List<object> { viewModel };
                    comboBoxToLoadInto.SelectedItem = viewModel;
                }
            }
        }

        /// <summary>
        /// Loads the station, which was selected in the list view and shows its details (coordinates, map).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListView lv && lv.SelectedItems.Count == 1)
            {
                var selectedItem = lv.SelectedItems[0];
                var stationTag = (TransportStation)selectedItem.Tag;
                this.groupBoxStationInformation.Text = stationTag.Name;
                this.tbStationLongitude.Text = stationTag.Coordinate.YCoordinate.ToString();
                this.tbStationLatitude.Text = stationTag.Coordinate.XCoordinate.ToString();
                var currentLocation = this.locationQueryService.GetCurrentLocation();
                var currentGeoLocation = new GeoCoordinate(
                    currentLocation.Latitude,
                    currentLocation.Longitude);
                var stationGeoLocation = new GeoCoordinate(
                    stationTag.Coordinate.YCoordinate,
                    stationTag.Coordinate.XCoordinate);
                var distance = Math.Round(currentGeoLocation.GetDistanceTo(stationGeoLocation) / 1000, 0);
                this.tbDistance.Text = $"{distance} km";
                var gmapsUrl = $"https://www.google.ch/maps/@{this.tbStationLatitude.Text},{this.tbStationLongitude.Text},19z";
                this.wbStations.Navigate(gmapsUrl);
            }
        }

        /// <summary>
        /// Loads the new data, if the tab is changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbMoreStationBoardOptions.Checked = false;
            this.gbMoreStationOptions.Visible = false;
            this.lbSelectedTab.Text = ((TabControl)sender).SelectedTab.Text;
            await this.LoadCurrentLocationIntoComboboxes(this.cbDeparture, this.cbSearchStationBoard);
        }

        /// <summary>
        /// Gets the closest station view model to the current location.
        /// </summary>
        /// <returns>Returns the view model for the curent location <see cref="TransportStation"/>.</returns>
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

        /// <summary>
        /// Loads the current location view model into all <see cref="ComboBox"/> given.
        /// </summary>
        /// <param name="comboBoxesToApply">The <see cref="ComboBox"/> to laod the current location into.</param>
        /// <returns>Returns the task to be awaited.</returns>
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

        /// <summary>
        /// If the user did not manually select a station via the dialog or the dropdown of the
        /// <see cref="ComboBox"/>, this method will check the content of the <see cref="ComboBox"/>
        /// and load a station into the <see cref="ComboBox"/>, that is valid. The station is 
        /// only going to be loaded into the <see cref="ComboBox"/>, if there's only one result.
        /// </summary>
        /// <param name="combobox">The combobox to apply it for.</param>
        /// <param name="continuation">The continuation to execute.</param>
        /// <returns>The task to await.</returns>
        private async Task CheckIfComboboxStationEmpty(ComboBox combobox, Action continuation)
        {
            if (combobox.SelectedItem == null && combobox.Text != string.Empty)
            {
                var searchText = combobox.Text;
                var stationList = await Task.Run(() => this.actionHandler.HandleFunc(() =>
                    this.queryService.GetStations(searchText)));
                if (stationList != null && stationList.StationList.Any())
                {
                    if (stationList.StationList.Any(x => x.Name == searchText) ||
                        stationList.StationList.Count == 1)
                    {
                        // If there's only one result, create the view model and load it into the combo box
                        var viewModel = new ComboboxItemViewModel<TransportStation>(
                            stationList.StationList.FirstOrDefault(x => x.Name == searchText) ?? stationList.StationList.First(),
                            x => x.Name);
                        combobox.DataSource = new List<object> { viewModel };
                        combobox.SelectedItem = viewModel;
                    }
                }
            }

            // Invoke the continuation on the UI thread
            this.Invoke(continuation);
        }

        /// <summary>
        /// Loads the station baord into the list view.
        /// </summary>
        /// <returns>Returns the task to await.</returns>
        private async Task LoadStationBoard()
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
                    //// Construct time for station board
                    var constructedDateTime = this.cbMoreStationBoardOptions.Checked
                        ? this.ConstructDateTime(this.dtpStationBoardDate, this.dtpStationBoardTime)
                        : DateTime.Now;
                    //// Load stations
                    var stationBoard = await Task.Run(() =>
                        this.actionHandler.HandleFunc(() =>
                            this.queryService.GetStationBoard(stationId, constructedDateTime)));
                    if (stationBoard == null)
                    {
                        return;
                    }

                    //// Create and load view models
                    var listViewItems = await Task.Run(() => this.actionHandler.HandleFunc(() =>
                        stationBoard.Map<StationBoardRoot, IEnumerable<ListViewItem>>().ToArray()));
                    this.lvStationBoard.Items.AddRange(listViewItems);
                }
            }
        }

        /// <summary>
        /// Prevents the user from resizing the given <see cref="ListView"/> column.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Stations_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvStations.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        /// <summary>
        /// Loads <see cref="TransportStation"/> near the current user into the search list view for the stations.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void ShowStationsNear_Click(object sender, EventArgs e)
        {
            using (new ProgressBarRunner(this.progressBar))
            {
                // Load stations close to the user
                var stationsClose = await Task.Run(() => this.actionHandler.HandleFunc(
                    () => this.locatableStationService.GetClosestStations(),
                    ex => MessageBox.Show(
                        "Ihr Standort konnte nicht gefunden werden oder es wurden zu viele Anfragen gemacht. Bitte versuchen Sie es später erneut.",
                        string.Empty,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)));
                if (stationsClose == null)
                {
                    return;
                }

                // Create and load view models
                var viewModels = this.actionHandler.HandleFunc(() =>
                    stationsClose.MapCollection<TransportStation, ListViewItem>().ToArray());
                this.lvStations.Items.Clear();
                this.lvStations.Items.AddRange(viewModels);
            }
        }

        /// <summary>
        /// Shows the dialog to send the email.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connections = this.lvConnections.Items.OfType<ListViewItem>().Select(x => x.Tag);
            if (connections.All(x => x is TransportConnection) && connections.Any() && this.tabControl.SelectedIndex == 0)
            {
                using (var dialog = new SendMailForm(
                    connections.Select(x => x as TransportConnection),
                    Properties.Settings.Default.SmtpHost,
                    Properties.Settings.Default.SmtpPort,
                    Properties.Settings.Default.UserName,
                    Properties.Settings.Default.Password,
                    Properties.Settings.Default.UserName))
                {
                    dialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(
                    "Bitte suchen sie zuerst nach Verbindungen.",
                    string.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Shows the settings dialog.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SettingsForm())
            {
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// Searches stations, if the users presses enter.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SearchStation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btStationSearch.PerformClick();
            }
        }

        /// <summary>
        /// Toggles the visibility of more options for the stations.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MoreStationBoardOptions_CheckedChanged(object sender, EventArgs e) =>
            this.gbMoreStationOptions.Visible = !this.gbMoreStationOptions.Visible;

        /// <summary>
        /// Checks, if the comboxbox has no valid value, and then tries to laod one, if possible.
        /// Validates the controls after that.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void ConnectionStationSelectionCombobox_Leave(object sender, EventArgs e) =>
            await this.CheckIfComboboxStationEmpty(sender as ComboBox, this.ValidateConnectionSearchButton);

        /// <summary>
        /// Checks, if the comboxbox has no valid value, and then tries to laod one, if possible.
        /// Validates the controls after that.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void StationBoardStationSelectionCombobox_Leave(object sender, EventArgs e) =>
            await this.CheckIfComboboxStationEmpty(sender as ComboBox, this.ValidateSearchStationButton);

        /// <summary>
        /// Loads the station board.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void SearchStationBoard_Click(object sender, EventArgs e) =>
            await this.LoadStationBoard();

        /// <summary>
        /// Constructs the <see cref="DateTime"/> from a date <see cref="DateTimePicker"/> and a 
        /// time <see cref="DateTimePicker"/>.
        /// </summary>
        /// <param name="datePicker">The <see cref="DateTimePicker"/> for the date.</param>
        /// <param name="timePicker">The <see cref="DateTimePicker"/> for the time.</param>
        /// <returns>The constructed <see cref="DateTime"/>.</returns>
        private DateTime ConstructDateTime(DateTimePicker datePicker, DateTimePicker timePicker) =>
            datePicker.Value.Date
                        .AddHours(timePicker.Value.Hour)
                        .AddMinutes(timePicker.Value.Minute);

        /// <summary>
        /// Validates the connection search button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ConnectionButtonValidation(object sender, EventArgs e) =>
            this.ValidateConnectionSearchButton();

        /// <summary>
        /// Validates the station board display button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void StationBoardDisplayButtonValidation(object sender, EventArgs e) =>
            this.ValidateStationBoardDisplayButton();

        /// <summary>
        /// Checks whether a valid station board station is selected.
        /// </summary>
        /// <returns>True, if there is a valid statio board station selected. Otherwise false.</returns>
        private bool IsValidStationBoardStation() =>
            ComboboxValidater.ContainValidLocations(this.cbSearchStationBoard);

        /// <summary>
        /// Checks whether there are valid stations selected for the arrival and departure.
        /// </summary>
        /// <returns>Returns true, if the selections are valid. Otherwise false.</returns>
        private bool AreValidConnectionStationsSelected() =>
            ComboboxValidater.ContainValidLocations(this.cbArrival, this.cbDeparture);
        
        /// <summary>
        /// Validates the station board display button and enables or disables it.
        /// </summary>
        private void ValidateStationBoardDisplayButton() =>
            this.btSearchStationBoard.Enabled = this.IsValidStationBoardStation() && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        /// <summary>
        /// Validates the connection search button and enables or disables it.
        /// </summary>
        private void ValidateConnectionSearchButton() =>
            this.btSearchConnections.Enabled = this.AreValidConnectionStationsSelected() && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        /// <summary>
        /// Validates the search station display button and enables or disables it.
        /// </summary>
        private void ValidateSearchStationButton() =>
            this.btStationSearch.Enabled = this.tbSearchStation.Text != string.Empty && this.progressBar.Style != ProgressBarStyle.Marquee
                ? true
                : false;

        /// <summary>
        /// Validates the station search button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SearchStation_TextChanged(object sender, EventArgs e) =>
            this.ValidateSearchStationButton();

        /// <summary>
        /// Loads the current locations into the comboboxes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void SwissTransportMainForm_Load(object sender, EventArgs e) =>
            await this.LoadCurrentLocationIntoComboboxes(this.cbDeparture, this.cbSearchStationBoard);

        /// <summary>
        /// Refreshes the station board.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void TimerStationBoard_Tick(object sender, EventArgs e) =>
            await this.LoadStationBoard();

        /// <summary>
        /// Show the search station dialog for the departure.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SelectDepartureStation_Click(object sender, EventArgs e) =>
            this.SearchStationDialog(this.cbDeparture);

        /// <summary>
        /// Show the search station dialog for the arrival.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SelectArrivalStation_Click(object sender, EventArgs e) =>
            this.SearchStationDialog(this.cbArrival);

        /// <summary>
        /// Show the search station dialog for the station board search.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SelectStationBoardStation_Click(object sender, EventArgs e) =>
            this.SearchStationDialog(this.cbSearchStationBoard);

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CloseApplication_Click(object sender, EventArgs e) =>
            Application.Exit();
    }
}
