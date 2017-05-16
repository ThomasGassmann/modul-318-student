namespace SwissTransport.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class StationBoardRoot
    {
        [JsonProperty("Station")]
        public Station Station { get; set; }

        [JsonProperty("stationboard")]
        public List<StationBoard> Entries { get; set; }
    }
}