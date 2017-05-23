namespace SwissTransport.DataAccess
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    /// <inheritdoc />
    public class TransportationQueryService : IQueryService
    {
        /// <inheritdoc />
        public StationCollection GetStations(string query) =>
            this.GetStations(new KeyValuePair<string, string>("query", query));

        /// <inheritdoc />
        public StationCollection GetStationsNear(double x, double y) =>
            this.GetStations(new KeyValuePair<string, string>("x", x.ToString()), new KeyValuePair<string, string>("y", y.ToString()));

        /// <inheritdoc />
        public StationBoardRoot GetStationBoard(string id, DateTime dateTime) =>
            this.GetStationBoard("id", id, dateTime);

        /// <inheritdoc />
        public StationBoardRoot GetStationBoardByName(string name, DateTime dateTime) =>
            this.GetStationBoard("station", name, dateTime);

        /// <inheritdoc />
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

        /// <inheritdoc />
        public ConnectionCollection GetConnections(string fromStation, string toStation) =>
            this.GetConnections(fromStation, toStation, DateTime.Now, false);
        
        /// <summary>
        /// Gets the station with the given paraemters.
        /// </summary>
        /// <param name="parameters">The parameters formatted as <see cref="KeyValuePair{TKey, TValue}"/>.</param>
        /// <returns>Returns all the stations found.</returns>
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

        /// <summary>
        /// Creates a web request to the given url.
        /// </summary>
        /// <param name="url">The url to create the request to.</param>
        /// <returns>Returns the created web request.</returns>
        private static WebRequest CreateWebRequest(string url)
        {
            var request = WebRequest.Create(url);
            var webProxy = WebRequest.DefaultWebProxy;
            webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Proxy = webProxy;
            return request;
        }

        /// <summary>
        /// Gets the station board with the given parameters.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="dateTime">The time to get the station board at.</param>
        /// <returns>Returns the station board.</returns>
        private StationBoardRoot GetStationBoard(string paramName, string paramValue, DateTime dateTime)
        {
            var formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm").Replace(" ", "%20");
            var query =
                $"http://transport.opendata.ch/v1/stationboard?{paramName}={paramValue}&datetime={formattedDateTime}";
            var request = TransportationQueryService.CreateWebRequest(query);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                var readToEnd = new StreamReader(responseStream).ReadToEnd();
                var jsonObject = JObject.Parse(readToEnd);
                var parse = true;
                try
                {
                    jsonObject["station"].Value<bool>();
                    parse = false;
                }
                catch (InvalidCastException)
                {
                }

                if (!parse)
                {
                    throw new InvalidOperationException("Die Station ist invalid.");
                }

                var stationboard =
                    JsonConvert.DeserializeObject<StationBoardRoot>(readToEnd);
                return stationboard;
            }

            return null;
        }
    }
}
