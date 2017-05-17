namespace SwissTransport.UI.ActionHandlers
{
    using System;

    public interface IActionHandler
    {
        void HandleAction(Action action, Action<Exception> exceptionHandler);

        T HandleFunc<T>(Func<T> func, Action<Exception> exceptionHandler);

        void HandleAction(Action action);

        T HandleFunc<T>(Func<T> func);
    }
}
