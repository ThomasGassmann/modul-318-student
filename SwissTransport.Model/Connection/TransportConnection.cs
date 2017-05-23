namespace SwissTransport.Model.Connection
{
    using System;
    using Newtonsoft.Json;
    using System.Globalization;

    /// <summary>
    /// Defines the transport connection.
    /// </summary>
    public class TransportConnection
    {
        /// <summary>
        /// Gets or sets the from connection point.
        /// </summary>
        [JsonProperty("from")]
        public ConnectionPoint From { get; set; }

        /// <summary>
        /// Gets or sets the to connection point.
        /// </summary>
        [JsonProperty("to")]
        public ConnectionPoint To { get; set; }

        /// <summary>
        /// Gets or sets the duration of the connection.
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets the <see cref="TimeSpan"/> of the duration.
        /// </summary>
        /// <returns>The duration.</returns>
        public TimeSpan GetDuration() =>
            this.Duration == null
                  ? this.To.ArrivalDateTime - this.From.DepartureDateTime
                  : TimeSpan.ParseExact(
                      this.Duration.Replace('d', '.'),
                      "c",
                      CultureInfo.CurrentCulture);

        /// <summary>
        /// Returns the duration as a formatted string.
        /// </summary>
        /// <returns>The formatted duration.</returns>
        public string GetDurationString()
        {
            var timeSpan = this.GetDuration();
            return $@"{(timeSpan.Days != 0 ? $"{timeSpan.Days.ToString()}d" : string.Empty)} {(timeSpan.Hours != 0 ? $"{timeSpan.Hours.ToString()}h" : string.Empty)} {(timeSpan.Minutes != 0 ? $"{timeSpan.Minutes.ToString()}m" : string.Empty)}";
        }
    }
}
