namespace SwissTransport.UI.Common
{
    using SwissTransport.UI.Common.Interfaces;
    using System;
    using System.Windows.Forms;

    public class ProgressBarRunner : IProgressBarRunner
    {
        private readonly Action disposeExecuteAction;

        public ProgressBarRunner(ProgressBar progressBarToHandle, Action disposeExecuteAction = null)
        {
            this.ProgressBar = progressBarToHandle;
            this.disposeExecuteAction = disposeExecuteAction;
            this.ProgressBar.Style = ProgressBarStyle.Marquee;
        }

        public ProgressBar ProgressBar { get; }

        public void Dispose()
        {
            this.ProgressBar.Style = ProgressBarStyle.Blocks;
            this.disposeExecuteAction?.Invoke();
        }
    }
}
