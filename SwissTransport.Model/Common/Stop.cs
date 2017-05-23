namespace SwissTransport.Model.Common
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a stop.
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// Gets or sets the departure time.
        /// </summary>
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }
    }
}
