namespace SwissTransport.Test
{
    using System;
    using System.Net;
    using System.Threading;

    /// <summary>
    /// Handles the unit test actions, that make web requests.
    /// </summary>
    public static class UnitTestActionHandler
    {
        /// <summary>
        /// Handles the function.
        /// </summary>
        /// <typeparam name="T">The return type of the function to handle.</typeparam>
        /// <param name="function">The function to handle.</param>
        /// <returns>The function result.</returns>
        public static T ExecuteUnitTestFunction<T>(Func<T> function)
        {
            var repeat = false;
            do
            {
                try
                {
                    var response = function();
                    return response;
                }
                catch (WebException ex)
                {
                    repeat = false;
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = ex.Response as HttpWebResponse;
                        if ((int)response.StatusCode == 429)
                        {
                            Thread.Sleep(500);
                            repeat = true;
                        }
                    }
                }
            }
            while (repeat);
            return default(T);
        }
    }
}
