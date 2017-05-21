namespace SwissTransport.DataAccess
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Location;
    using System.Net;

    /// <inheritdoc />
    public class LocationQueryService : ILocationQueryService
    {
        /// <inheritdoc />
        public IPLocation GetCurrentLocation()
        {
            using (var webClient = new WebClient())
            {
                var locationJson = webClient.DownloadString("http://ip-api.com/json");
                return JsonConvert.DeserializeObject<IPLocation>(locationJson);
            }
        }
    }
}
