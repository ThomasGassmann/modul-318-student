namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;

    public class ConnectionPoint
    {
        [JsonProperty("station")]
        public TransportStation Station { get; set; }

        public string Arrival { get; set; }

        public string ArrivalTimestamp { get; set; }

        public string Departure { get; set; }

        public string DepartureTimestamp { get; set; }

        public int? Delay { get; set; }

        public string Platform { get; set; }

        public string RealtimeAvailability { get; set; }
    }
}
