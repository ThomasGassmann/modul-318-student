namespace SwissTransport.Model.StationBoard
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the root of the station board.
    /// </summary>
    public class StationBoardRoot
    {
        /// <summary>
        /// Gets or sets the station board root station.
        /// </summary>
        [JsonProperty("Station")]
        public TransportStation Station { get; set; }

        /// <summary>
        /// Gets or sets all endpoints of the given root station.
        /// </summary>
        [JsonProperty("stationboard")]
        public List<TransportStationBoard> Entries { get; set; }
    }
}