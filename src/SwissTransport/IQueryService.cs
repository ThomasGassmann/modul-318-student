namespace SwissTransport.DataAccess
{
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using System;

    public interface IQueryService
    {
        StationCollection GetStations(string query);

        StationBoardRoot GetStationBoard(string station, string id);

        ConnectionCollection GetConnections(string fromStation, string toStation);

        ConnectionCollection GetConnections(string fromStation, string toStation, DateTime time, bool isArrivalTime);
    }
}