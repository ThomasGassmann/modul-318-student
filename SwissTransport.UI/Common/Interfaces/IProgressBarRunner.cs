namespace SwissTransport.UI.Common.Interfaces
{
    using System;
    using System.Windows.Forms;

    public interface IProgressBarRunner : IDisposable
    {
        ProgressBar ProgressBar { get; }
    }
}
