namespace SwissTransport.Model.Location
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a location.
    /// </summary>
    public class SwissTransportGeoLocation
    {
        /// <summary>
        /// Gets or sets the status of the result from the API.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets a value determining whether the API result was successful.
        /// </summary>
        public bool Success => this.Status == "success";
    }
}
