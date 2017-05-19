namespace SwissTransport.Model.Location
{
    using Newtonsoft.Json;

    public class IPLocation
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        public bool Success => this.Status == "success";
    }
}
