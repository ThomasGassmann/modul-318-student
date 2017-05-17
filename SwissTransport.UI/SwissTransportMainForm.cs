namespace SwissTransport.UI
{
    using SwissTransport.DataAccess;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.ViewModels;
    using System;
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
                var stations = await Task.Run(
                    () => this.queryService.GetStations(comboBoxText));
                if (stations == default(StationCollection))
                {
                    return;
                }

                var selectedViewModels = stations.StationList.Select(x =>
                    new ComboboxItemViewModel<TransportStation>(x, f => f.Name));
                cb.DataSource = selectedViewModels.ToArray();
                cb.Text = comboBoxText;
                cb.SelectionStart = selectionStart;
                cb.SelectionLength = length;
            }
        }
    }
}
