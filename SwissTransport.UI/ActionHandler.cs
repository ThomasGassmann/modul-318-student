namespace SwissTransport.UI
{
    using System;
    using System.Windows.Forms;

    public class ActionHandler
    {
        public void HandleAction(Action action) =>
            this.HandleAction(action, this.ShowDefaultExceptionWindow);

        public void HandleAction(Action action, Action<Exception> exceptionHandler)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                exceptionHandler(ex);
            }
        }

        public void ShowDefaultExceptionWindow(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
