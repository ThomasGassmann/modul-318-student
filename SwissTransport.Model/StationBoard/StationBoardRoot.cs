namespace SwissTransport.Model.StationBoard
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;
    using System.Collections.Generic;

    public class StationBoardRoot
    {
        [JsonProperty("Station")]
        public TransportStation Station { get; set; }

        [JsonProperty("stationboard")]
        public List<TransportStationBoard> Entries { get; set; }
    }
}