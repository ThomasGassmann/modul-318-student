namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Defines a collection of connections.
    /// </summary>
    public class ConnectionCollection
    {
        /// <summary>
        /// Gets or sets the connections.
        /// </summary>
        [JsonProperty("connections")]
        public List<TransportConnection> ConnectionList { get; set; }
    }
}