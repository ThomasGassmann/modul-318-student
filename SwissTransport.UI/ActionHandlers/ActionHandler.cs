namespace SwissTransport.UI.ActionHandlers
{
    using System;
    using System.Net;
    using System.Windows.Forms;

    public class ActionHandler : IActionHandler
    {
        private readonly SwissTransportMainForm uiForm;

        public ActionHandler(SwissTransportMainForm form) =>
            this.uiForm = form;

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
            var errorMessage = string.Empty;
            switch (ex)
            {
                case WebException webException:
                    errorMessage = "Eine ungültige Antwort wurde von der API zurück gesendet.";
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

            if (this.uiForm != null)
            {
                this.uiForm.Invoke(new Action(() => MessageBox.Show(errorMessage)));
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
