namespace SwissTransport.UI.Forms
{
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Defines a form to select a <see cref="TransportStation"/>.
    /// </summary>
    public partial class StationSelector : Form
    {
        /// <summary>
        /// Stores the action handler to handle the actions.
        /// </summary>
        private readonly IActionHandler actionHandler;

        /// <summary>
        /// Stores the query service to query the API for the transportation data.
        /// </summary>
        private readonly IQueryService queryService = new TransportationQueryService();

        /// <summary>
        /// Stores the service to get stations close to the current location.
        /// </summary>
        private readonly ILocatableStationService locatableStationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationSelector"/> class.
        /// </summary>
        public StationSelector()
        {
            this.InitializeComponent();
            this.actionHandler = new ActionHandler(this);
            var locationQueryService = new LocationQueryService();
            this.locatableStationService = new LocatableStationService(locationQueryService, this.queryService);
            this.tbSearch.Focus();
        }

        /// <summary>
        /// Gets the selected station.
        /// </summary>
        public TransportStation SelectedStation { get; private set; }

        /// <summary>
        /// Prevents the user from resizing the column.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void StationsListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvStations.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        /// <summary>
        /// Enables or disables the OK button, depending on when the <see cref="ListView"/> contains a valid item.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListView lv && lv.SelectedItems.Count == 1)
            {
                var selectedItem = lv.SelectedItems[0].Tag;
                this.btOk.Enabled = false;
                if (selectedItem is TransportStation t)
                {
                    this.SelectedStation = t;
                    this.lbSelectedStation.Text = t.Name;
                    this.btOk.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Loads stations close to the user into the <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void StationSelector_Load(object sender, EventArgs e) =>
            await this.LoadStationListView(
                () => this.locatableStationService.GetClosestStations(),
                ex =>
                {
                });

        /// <summary>
        /// Loads stations close to the user into the <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void CloseToMe_Click(object sender, EventArgs e) =>
            await this.LoadStationListView(
                () => this.locatableStationService.GetClosestStations(),
                ex => MessageBox.Show("Der aktuelle Standort konnte nicht gefunden werden oder zu viele Requests wurden an den Server gestellt."));

        /// <summary>
        /// Loads the found <see cref="TransportStation"/> into the <see cref="ListView"/>.
        /// </summary>
        /// <param name="searchTerm">The search query.</param>
        /// <returns>The task to be awaited.</returns>
        private async Task LoadStationListView(string searchTerm) =>
            await this.LoadStationListView(
                () => this.queryService.GetStations(searchTerm).StationList,
                ex => 
                {
                });

        /// <summary>
        /// Loads the items of the given function into the <see cref="ListView"/>, if the function
        /// will not result in an exception.
        /// </summary>
        /// <param name="stationFunc">The function to get the stations.</param>
        /// <param name="exceptionHanlder">The action to handle the exception, if there's an exception.</param>
        /// <returns>Returns the task to be awaited.</returns>
        private async Task LoadStationListView(
            Func<IEnumerable<TransportStation>> stationFunc,
            Action<Exception> exceptionHanlder)
        {
            this.btCloseToMe.Enabled = false;
            using (new ProgressBarRunner(this.progressStationSearch, () => this.btCloseToMe.Enabled = true))
            {
                var stations = await Task.Run(() => this.actionHandler.HandleFunc(
                    stationFunc,
                    exceptionHanlder));
                if (stations == null)
                {
                    return;
                }

                var viewModels = this.actionHandler.HandleFunc(() =>
                    stations.MapCollection<TransportStation, ListViewItem>().ToArray());
                this.lvStations.Items.Clear();
                this.lvStations.Items.AddRange(viewModels);
            }
        }

        /// <summary>
        /// Loads stations to the user into the <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void Search_TextChanged(object sender, EventArgs e) =>
            await this.LoadStationListView(this.tbSearch.Text);

        /// <summary>
        /// Loads stations close to the user intot the <see cref="ListView"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void Search_Click(object sender, EventArgs e) =>
            await this.LoadStationListView(this.tbSearch.Text);
    }
}
