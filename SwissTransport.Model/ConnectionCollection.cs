namespace SwissTransport.Model
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ConnectionCollection
    {
        [JsonProperty("connections")]
        public List<Connection> ConnectionList { get; set; } 
    }
}