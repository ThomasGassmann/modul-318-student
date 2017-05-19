namespace SwissTransport.Model.Connection
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ConnectionCollection
    {
        [JsonProperty("connections")]
        public List<TransportConnection> ConnectionList { get; set; }
    }
}