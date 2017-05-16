namespace SwissTransport.UI
{
    using System.Windows.Forms;

    public partial class SwissTransportMainForm : Form
    {
        public SwissTransportMainForm()
        {
            this.InitializeComponent();
        }

        private void ShowExtendedOptions_CheckedChanged(object sender, System.EventArgs e) =>
            this.gbExtendedOptions.Visible = !this.gbExtendedOptions.Visible;
    }
}
