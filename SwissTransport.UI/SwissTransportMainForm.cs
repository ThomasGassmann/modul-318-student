namespace SwissTransport.UI
{
    using SwissTransport.DataAccess;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Validation;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.ViewModels;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using SwissTransport.Model.Connection;

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
                    ? this.dtpConnectionSearchDate.Value.Date
                        .AddHours(this.dtpConnectionSearchTime.Value.Hour)
                        .AddMinutes(this.dtpConnectionSearchTime.Value.Minute)
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

        private void ConnectionButtonValidation(object sender, EventArgs e) =>
            this.ValidateConnectionSearchButton();

        private bool AreValidConnectionStationsSelected() =>
            ComboboxValidater.ContainValidLocations(this.cbArrival, this.cbDeparture);

        private void ValidateConnectionSearchButton()
        {
            this.btSearchConnections.Enabled = false;
            if (this.AreValidConnectionStationsSelected())
            {
                this.btSearchConnections.Enabled = true;
            }
        }
    }
}
