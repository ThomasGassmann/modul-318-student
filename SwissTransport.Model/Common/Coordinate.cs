namespace SwissTransport.Model.Common
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a location.
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Gets or sets the type of the location.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        [JsonProperty("x")]
        public double XCoordinate { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        [JsonProperty("y")]
        public double YCoordinate { get; set; }
    }
}
