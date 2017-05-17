namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;
    using System;

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

        public DateTime DepartureDateTime
        {
            get
            {
                DateTime.TryParse(this.Departure, out var returnValue);
                return returnValue;
            }
        }

        public DateTime ArrivalDateTime
        {
            get
            {
                DateTime.TryParse(this.Arrival, out var returnValue);
                return returnValue;
            }
        }
    }
}
