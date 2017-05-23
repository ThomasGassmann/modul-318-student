namespace SwissTransport.UI.Common.Interfaces
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines a progress bar runner to run the progress bar until disposed.
    /// </summary>
    public interface IProgressBarRunner : IDisposable
    {
        /// <summary>
        /// Gets the progress bar to run.
        /// </summary>
        ProgressBar ProgressBar { get; }
    }
}
