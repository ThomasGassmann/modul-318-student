﻿namespace SwissTransport.UI
{
    using SwissTransport.UI.Forms;
    using System;
    using System.Diagnostics;
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
            SetFeatureBrowserEmulation.SetIEKeyforWebBrowserControl(Process.GetCurrentProcess());
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => MessageBox.Show("Ein unerwarteter Fehler ist aufgetreten.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SwissTransportMainForm());
        }
    }
}
