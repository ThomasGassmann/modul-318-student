﻿namespace SwissTransport.Model.Common
{
    using Newtonsoft.Json;
    using System;

    public class Stop
    {
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }
    }
}