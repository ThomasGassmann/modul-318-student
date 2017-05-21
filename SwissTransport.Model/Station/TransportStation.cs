namespace SwissTransport.Model.Station
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Common;

    /// <summary>
    /// Defines a transpor station.
    /// </summary>
    public class TransportStation
    {
        /// <summary>
        /// Gets or sets the station id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the station score.
        /// </summary>
        [JsonProperty("score")]
        public int? Score { get; set; }

        /// <summary>
        /// Gets or sets the station coordinates.
        /// </summary>
        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Gets or sets the distance to the current location, if given.
        /// </summary>
        [JsonProperty("distance")]
        public double? Distance { get; set; }
    }
}
