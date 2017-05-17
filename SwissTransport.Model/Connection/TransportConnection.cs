namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;

    public class TransportConnection
    {
        [JsonProperty("from")]
        public ConnectionPoint From { get; set; }

        [JsonProperty("to")]
        public ConnectionPoint To { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }
    }
}
