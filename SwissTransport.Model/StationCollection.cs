namespace SwissTransport.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class StationCollection
    {
        [JsonProperty("stations")]
        public List<Station> StationList { get; set; }
    }
}