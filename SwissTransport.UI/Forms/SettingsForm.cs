namespace SwissTransport.UI.Forms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the settings form.
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class. 
        /// Loads the values into the textboxes.
        /// </summary>
        public SettingsForm()
        {
            this.InitializeComponent();
            this.tbPassword.Text = Properties.Settings.Default.Password;
            this.tbUserName.Text = Properties.Settings.Default.UserName;
            this.tbSmtpHost.Text = Properties.Settings.Default.SmtpHost;
            this.numSmtpPort.Value = (decimal)Properties.Settings.Default.SmtpPort;
        }

        /// <summary>
        /// Saves the values to the properties file.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Save_Click(object sender, EventArgs e) =>
            Properties.Settings.Default.Save();

        /// <summary>
        /// Changes the value in the properties of the new SMTP host.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SmtpHost_TextChanged(object sender, EventArgs e) =>
            Properties.Settings.Default.SmtpHost = this.tbSmtpHost.Text;

        /// <summary>
        /// Changes the value in the properties of the new SMTP port.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SmtpPort_ValueChanged(object sender, EventArgs e) =>
            Properties.Settings.Default.SmtpPort = (int)this.numSmtpPort.Value;

        /// <summary>
        /// Changes the value in the properties of the new user name.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UserName_TextChanged(object sender, EventArgs e) =>
            Properties.Settings.Default.UserName = this.tbUserName.Text;

        /// <summary>
        /// Changes the value in the properties of the new password.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Password_TextChanged(object sender, EventArgs e) =>
            Properties.Settings.Default.Password = this.tbPassword.Text;
    }
}
