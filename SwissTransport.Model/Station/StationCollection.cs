namespace SwissTransport.Model.Station
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class StationCollection
    {
        [JsonProperty("stations")]
        public List<TransportStation> StationList { get; set; }
    }
}