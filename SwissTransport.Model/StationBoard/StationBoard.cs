namespace SwissTransport.Model.StationBoard
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Common;

    /// <summary>
    /// Defines the station board.
    /// </summary>
    public class TransportStationBoard
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [JsonProperty("Number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the to of the station board.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the operator of the line.
        /// </summary>
        [JsonProperty("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the stop.
        /// </summary>
        [JsonProperty("stop")]
        public Stop Stop { get; set; }
    }
}
