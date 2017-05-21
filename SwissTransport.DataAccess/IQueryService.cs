namespace SwissTransport.DataAccess
{
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using System;

    /// <summary>
    /// Defines the query service to get the transport data.
    /// </summary>
    public interface IQueryService
    {
        /// <summary>
        /// Gets the stations corresponding to the given query.
        /// </summary>
        /// <param name="query">The query to search for.</param>
        /// <returns>Returns the stations, that were found.</returns>
        StationCollection GetStations(string query);

        /// <summary>
        /// Gets all stations near the given coordinates.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinte.</param>
        /// <returns>Returns the stations near the given location.</returns>
        StationCollection GetStationsNear(double x, double y);

        /// <summary>
        /// Gets the station board at a given time.
        /// </summary>
        /// <param name="id">The id of the station to get the station board for.</param>
        /// <param name="dateTime">The time to get the station board at.</param>
        /// <returns>Returns the station board.</returns>
        StationBoardRoot GetStationBoard(string id, DateTime dateTime);

        /// <summary>
        /// Gets the station board by it's name instead of the id.
        /// </summary>
        /// <param name="name">The name of the station.</param>
        /// <param name="dateTime">The time to get the station board at.</param>
        /// <returns>Returns the station board.</returns>
        StationBoardRoot GetStationBoardByName(string name, DateTime dateTime);

        /// <summary>
        /// Gets the connection between two stations.
        /// </summary>
        /// <param name="fromStation">The departure station.</param>
        /// <param name="toStation">The arrival station.</param>
        /// <returns>Returns the connections.</returns>
        ConnectionCollection GetConnections(string fromStation, string toStation);

        /// <summary>
        /// Gets the connection between two stations at a given time..
        /// </summary>
        /// <param name="fromStation">The departure station.</param>
        /// <param name="toStation">The arrival station.</param>
        /// <param name="time">The time to get the connections at.</param>
        /// <param name="isArrivalTime">Determines whether the time is arrival or departure time.</param>
        /// <returns>Returns the connections.</returns>
        ConnectionCollection GetConnections(string fromStation, string toStation, DateTime time, bool isArrivalTime);
    }
}