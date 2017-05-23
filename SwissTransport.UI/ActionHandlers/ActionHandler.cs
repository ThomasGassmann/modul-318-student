namespace SwissTransport.UI.ActionHandlers
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Windows.Forms;

    /// <summary>
    /// Defines an implementation of an <see cref="IActionHandler"/> which handles all actions 
    /// coming from the UI and deal with unsafe (potentially invalid) user input.
    /// </summary>
    public class ActionHandler : IActionHandler
    {
        /// <summary>
        /// Contains the UI form. This field is used to call actions on the UI thread.
        /// For example <see cref="MessageBox"/> needs to be called on the UI thread, 
        /// to display it modal.
        /// </summary>
        private readonly Form uiForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionHandler"/> class. Sets the UI form.
        /// </summary>
        /// <param name="form">The form to invoke the UI actions on.</param>
        public ActionHandler(Form form) =>
            this.uiForm = form;

        /// <inheritdoc />
        public T HandleFunc<T>(Func<T> func) =>
            this.HandleFunc(func, this.ShowDefaultExceptionWindow);

        /// <inheritdoc />
        public void HandleAction(Action action) =>
            this.HandleAction(action, this.ShowDefaultExceptionWindow);

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void HandleAction(Action action, Action<Exception> exceptionHandler) =>
            this.HandleFunc(
            () =>
            {
                action();
                //// Return 0, because the return value is not used.
                return 0;
            }, 
            exceptionHandler);

        /// <summary>
        /// Shows the default exception window for a given <see cref="Exception"/>.
        /// </summary>
        /// <param name="ex">The <see cref="Exception"/> to display the modal dialog for.</param>
        private void ShowDefaultExceptionWindow(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            var errorMessage = string.Empty;
            switch (ex)
            {
                case WebException webException:
                    errorMessage = "Eine ungültige Antwort wurde von der API zurück gesendet. Bitte überprüfen Sie ihre Angaben.";
                    if (webException.Response is HttpWebResponse response && 
                        webException.Status == WebExceptionStatus.ProtocolError)
                    {
                        switch ((int)response.StatusCode)
                        {
                            case 429:
                                errorMessage = "Es wurden zu viele Anfragen auf die Web API gemacht.";
                                break;
                            case (int)HttpStatusCode.NotFound:
                            case (int)HttpStatusCode.RequestTimeout:
                                errorMessage = "Die API konnte nicht gefunden werden. Bitte überprüfen Sie ihre Internetverbindung.";
                                break;
                            default:
                                break;
                        }
                    }

                    break;
                default:
                    var innerMostException = ex;
                    while (innerMostException.InnerException != null)
                    {
                        innerMostException = innerMostException.InnerException;
                    }

                    errorMessage = innerMostException.Message;
                    break;
            }

            Action messageBoxInvocation = () => MessageBox.Show(
                    errorMessage,
                    string.Empty,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            //// Execute the action on the UI form, if possible.
            (this.uiForm != null
                ? x => this.uiForm.Invoke(x)
                : new Action<Action>(x => x()))(messageBoxInvocation);
        }
    }
}
