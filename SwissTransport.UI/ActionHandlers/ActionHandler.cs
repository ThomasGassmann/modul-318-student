namespace SwissTransport.UI.ActionHandlers
{
    using System;
    using System.Windows.Forms;

    public class ActionHandler : IActionHandler
    {
        public T HandleFunc<T>(Func<T> func) =>
            this.HandleFunc<T>(func, this.ShowDefaultExceptionWindow);

        public void HandleAction(Action action) =>
            this.HandleAction(action, this.ShowDefaultExceptionWindow);

        public T HandleFunc<T>(Func<T> func, Action<Exception> exceptionHandler)
        {
            try
            {
                var value = func();
                return value;
            }
            catch (Exception ex)
            {
                exceptionHandler(ex);
            }

            return default(T);
        }

        public void HandleAction(Action action, Action<Exception> exceptionHandler) =>
            this.HandleFunc(() =>
            {
                action();
                return 0;
            }, exceptionHandler);

        private void ShowDefaultExceptionWindow(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
