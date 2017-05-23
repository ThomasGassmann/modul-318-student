namespace SwissTransport.UI.ActionHandlers
{
    using System;

    /// <summary>
    /// Defines an action handler to handle actions from the user interface.
    /// </summary>
    public interface IActionHandler
    {
        /// <summary>
        /// Handles an action with a custom exception handler.
        /// </summary>
        /// <param name="action">The action to handle.</param>
        /// <param name="exceptionHandler">The custom exception handler to handle <see cref="Exception"/>.</param>
        void HandleAction(Action action, Action<Exception> exceptionHandler);

        /// <summary>
        /// Handles a function with a custom exception handler.
        /// </summary>
        /// <typeparam name="T">The return type to handle.</typeparam>
        /// <param name="func">The function to handle.</param>
        /// <param name="exceptionHandler">The exception handler, beeing called if an <see cref="Exception"/> occurs.</param>
        /// <returns>Returns the evaluated value of the function. Returns the default value of T, if an exception occurs.</returns>
        T HandleFunc<T>(Func<T> func, Action<Exception> exceptionHandler);

        /// <summary>
        /// Handles an action with the default exception handler.
        /// </summary>
        /// <param name="action">The action to handle.</param>
        void HandleAction(Action action);

        /// <summary>
        /// Handles a function with the default exception handler.
        /// </summary>
        /// <typeparam name="T">The return type to handle.</typeparam>
        /// <param name="func">The function to handle.</param>
        /// <returns>Returns the value of the evaluated function.</returns>
        T HandleFunc<T>(Func<T> func);
    }
}
