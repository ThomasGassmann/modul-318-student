namespace SwissTransport.DataAccess
{
    using Newtonsoft.Json;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class TransportationQueryService : IQueryService
    {
        public StationCollection GetStations(string query) =>
            this.GetStations(new KeyValuePair<string, string>("query", query));

        public StationCollection GetStationsNear(double x, double y) =>
            this.GetStations(new KeyValuePair<string, string>("x", x.ToString()), new KeyValuePair<string, string>("y", y.ToString()));

        public StationBoardRoot GetStationBoard(string id, DateTime dateTime) =>
            this.GetStationBoard("id", id, dateTime);

        public StationBoardRoot GetStationBoardByName(string name, DateTime dateTime) =>
            this.GetStationBoard("station", name, dateTime);

        public ConnectionCollection GetConnections(string fromStation, string toStation, DateTime time, bool isArrivalTime)
        {
            var date = time.ToString("yyyy-MM-dd");
            var dateTime = time.ToString("HH:mm");
            var arrivalTimeValue = isArrivalTime ? "1" : "0";
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/connections?from={fromStation}&to={toStation}&date={date}&time={dateTime}&isArrivalTime={arrivalTimeValue}");
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

        public ConnectionCollection GetConnections(string fromStation, string toStation) =>
            this.GetConnections(fromStation, toStation, DateTime.Now, false);

        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;

            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            
            return request;
        }

        private StationBoardRoot GetStationBoard(string paramName, string paramValue, DateTime dateTime)
        {
            var formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm").Replace(" ", "%20");
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/stationboard?{paramName}={paramValue}&datetime={formattedDateTime}");
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

        public StationCollection GetStations(params KeyValuePair<string, string>[] parameters)
        {
            var parameterString = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
            var request = TransportationQueryService.CreateWebRequest(
                $"http://transport.opendata.ch/v1/locations?{parameterString}");
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
    }
}
