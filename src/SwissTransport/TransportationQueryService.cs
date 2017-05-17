namespace SwissTransport.DataAccess
{
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using SwissTransport.Model.Connection;

    public class TransportationQueryService : IQueryService
    {
        // TODO: Implement caching to prevent 429
        public StationCollection GetStations(string query)
        {
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/locations?query={query}");
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var message = new StreamReader(responseStream).ReadToEnd();
                var stations = JsonConvert.DeserializeObject<StationCollection>(message);
                return stations;
            }

            return null;
        }

        public StationBoardRoot GetStationBoard(string station, string id)
        {
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/stationboard?Station={station}&id={id}");
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var stationboard =
                    JsonConvert.DeserializeObject<StationBoardRoot>(readToEnd);
                return stationboard;
            }

            return null;
        }

        public ConnectionCollection GetConnections(string fromStation, string toStation)
        {
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/connections?from={fromStation}&to={toStation}");
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var connections =
                    JsonConvert.DeserializeObject<ConnectionCollection>(readToEnd);
                return connections;
            }

            return null;
        }

        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;

            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            
            return request;
        }
    }
}
