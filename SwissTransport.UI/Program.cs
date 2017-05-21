namespace SwissTransport.UI
{
    using SwissTransport.UI.Forms;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the main entry point of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SwissTransportMainForm());
        }
    }
}
