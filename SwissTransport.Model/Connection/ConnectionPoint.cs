namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;
    using System;

    /// <summary>
    /// Defines a connection point.
    /// </summary>
    public class ConnectionPoint
    {
        /// <summary>
        /// Gets or sets the station for the connection.
        /// </summary>
        [JsonProperty("station")]
        public TransportStation Station { get; set; }

        /// <summary>
        /// Gets or sets the arrival time as a string.
        /// </summary>
        public string Arrival { get; set; }

        /// <summary>
        /// Gets or sets the arrival time as a unix timestamp.
        /// </summary>
        public string ArrivalTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the departure time as a string.
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Gets or sets the departure time as a unix timestamp.
        /// </summary>
        public string DepartureTimestamp { get; set; }

        /// <summary>
        /// Gets or sets a value determining how late the connection is.
        /// </summary>
        public int? Delay { get; set; }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the availability.
        /// </summary>
        public string RealtimeAvailability { get; set; }

        /// <summary>
        /// Gets the departure time.
        /// </summary>
        public DateTime DepartureDateTime
        {
            get
            {
                DateTime.TryParse(this.Departure, out var returnValue);
                return returnValue;
            }
        }

        /// <summary>
        /// Gets the arrival time.
        /// </summary>
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
