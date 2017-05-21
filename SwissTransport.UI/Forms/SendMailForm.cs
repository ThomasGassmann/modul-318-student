namespace SwissTransport.UI.Forms
{
    using SwissTransport.Model.Connection;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.Common;
    using SwissTransport.UI.Properties;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the form to send mails.
    /// </summary>
    public partial class SendMailForm : Form
    {
        /// <summary>
        /// Stores the action handler.
        /// </summary>
        private readonly IActionHandler actionHandler;

        /// <summary>
        /// Contains a value determining, whether the current form is able to close itself.
        /// </summary>
        private bool canClose = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMailForm"/> class. SSL is activated by default.
        /// </summary>
        /// <param name="connections">The connections to send as an email.</param>
        /// <param name="smtpHost">The SMTP host.</param>
        /// <param name="smtpPort">The SMTP port.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="from">The address to send the mail from.</param>
        public SendMailForm(
            IEnumerable<TransportConnection> connections,
            string smtpHost,
            int smtpPort,
            string userName,
            string password,
            string from)
        {
            this.InitializeComponent();
            this.actionHandler = new ActionHandler(this);
            this.TransportConnections = connections;
            this.SmtpHost = smtpHost;
            this.SmtpPort = smtpPort;
            this.UserName = userName;
            this.Password = password;
            this.From = from;
            this.SuggestMailBody();
            this.tbTitle.Focus();
        }

        /// <summary>
        /// Gets all connections to handle.
        /// </summary>
        public IEnumerable<TransportConnection> TransportConnections { get; }

        /// <summary>
        /// Gets the SMTP host.
        /// </summary>
        public string SmtpHost { get; private set; }

        /// <summary>
        /// Gets the SMTP port.
        /// </summary>
        public int SmtpPort { get; private set; }

        /// <summary>
        /// Gets the user name.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets the address, from which the email is beeing sent.
        /// </summary>
        public string From { get; private set; }

        /// <summary>
        /// Handles the click on the send button and sends the email. If an error occurs, 
        /// an error message is displayed, as defined in the <see cref="IActionHandler"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Send_Click(object sender, System.EventArgs e)
        {
            using (new ProgressBarRunner(this.progress))
            {
                var to = this.tbMailTo.Text;
                var body = this.tbMailBody.Text;
                var title = this.tbTitle.Text;
                //// Handle the SMTP send action.
                this.actionHandler.HandleAction(
                    () =>
                    {
                        var smtpClient = new SmtpClient(this.SmtpHost, this.SmtpPort);
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential(this.UserName, this.Password);
                        var mailMessage = new MailMessage(new MailAddress(this.From), new MailAddress(to))
                        {
                            Body = body,
                            Subject = title
                        };
                        smtpClient.Send(mailMessage);
                        //// If the mail is sent successfully, the form is able to close.
                        this.canClose = true;
                    },
                    ex =>
                    {
                        MessageBox.Show("Die angegebenen Daten sind nicht valid. Bitte versuchen Sie es ernuet mit validen Daten.");
                        this.canClose = false;
                    });
            }
        }

        /// <summary>
        /// Suggests the mail body an adds it into the textbox.
        /// </summary>
        private void SuggestMailBody()
        {
            var stringBuilder = new StringBuilder();
            foreach (var connection in this.TransportConnections)
            {
                stringBuilder.AppendLine($"Von: {connection.From.Station.Name} ({(string.IsNullOrEmpty(connection.From.Platform) ? Resources.Empty : connection.From.Platform)})");
                stringBuilder.AppendLine($"Nach: {connection.To.Station.Name} ({(string.IsNullOrEmpty(connection.To.Platform) ? Resources.Empty : connection.To.Platform)})");
                stringBuilder.AppendLine($"Dauer: {connection.GetDurationString()}");
                stringBuilder.AppendLine($"Ab: {connection.From.DepartureDateTime}");
                stringBuilder.AppendLine($"An: {connection.To.ArrivalDateTime}");
                stringBuilder.AppendLine();
            }

            this.tbMailBody.Text = stringBuilder.ToString().Trim();
        }

        /// <summary>
        /// Handles the form closing event and closes the form, if it's able to close the form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SendMailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.canClose)
            {
                e.Cancel = true;
                this.canClose = true;
            }
        }

        /// <summary>
        /// Handles the cancel event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.canClose = true;
        }
    }
}
