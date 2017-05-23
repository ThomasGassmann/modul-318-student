namespace SwissTransport.Model.Station
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a collection of stations.
    /// </summary>
    public class StationCollection
    {
        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        [JsonProperty("stations")]
        public List<TransportStation> StationList { get; set; }
    }
}