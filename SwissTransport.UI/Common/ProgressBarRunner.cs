namespace SwissTransport.UI.Common
{
    using SwissTransport.UI.Common.Interfaces;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines an implementation to run the progress bar until a certain action is finished.
    /// The end of the action is defined by the <see cref="IDisposable"/> interface.
    /// </summary>
    public class ProgressBarRunner : IProgressBarRunner
    {
        /// <summary>
        /// Stores the action to be executed, after the progress bar finishes animating.
        /// </summary>
        private readonly Action disposeExecuteAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarRunner"/> class.
        /// </summary>
        /// <param name="progressBarToHandle">The progress bar to handle.</param>
        /// <param name="disposeExecuteAction">The action to execute after the <see cref="ProgressBar"/> finishes loading.</param>
        public ProgressBarRunner(ProgressBar progressBarToHandle, Action disposeExecuteAction = null)
        {
            this.ProgressBar = progressBarToHandle;
            this.disposeExecuteAction = disposeExecuteAction;
            this.ProgressBar.Style = ProgressBarStyle.Marquee;
        }

        /// <summary>
        /// Gets the <see cref="ProgressBar"/> to handle.
        /// </summary>
        public ProgressBar ProgressBar { get; }

        /// <summary>
        /// Disposes the class, stops the progress bar and executes the dispose action.
        /// </summary>
        public void Dispose()
        {
            this.ProgressBar.Style = ProgressBarStyle.Blocks;
            this.disposeExecuteAction?.Invoke();
        }
    }
}
