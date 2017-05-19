namespace SwissTransport.Model.Connection
{
    using System;
    using Newtonsoft.Json;
    using System.Globalization;

    public class TransportConnection
    {
        [JsonProperty("from")]
        public ConnectionPoint From { get; set; }

        [JsonProperty("to")]
        public ConnectionPoint To { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        public TimeSpan GetDuration() =>
            this.Duration == null
                  ? this.To.ArrivalDateTime - this.From.DepartureDateTime
                  : TimeSpan.ParseExact(
                      this.Duration.Replace('d', '.'),
                      "c",
                      CultureInfo.CurrentCulture);

        public string GetDurationString()
        {
            var timeSpan = this.GetDuration();
            return $@"{(timeSpan.Days != 0 ? $"{timeSpan.Days.ToString()}d" : string.Empty)} {(timeSpan.Hours != 0 ? $"{timeSpan.Hours.ToString()}h" : string.Empty)} {(timeSpan.Minutes != 0 ? $"{timeSpan.Minutes.ToString()}m" : string.Empty)}";
        }
    }
}
