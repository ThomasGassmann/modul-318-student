namespace SwissTransport.DataAccess
{
    using SwissTransport.Model.Connection;
    using SwissTransport.Model.Station;
    using SwissTransport.Model.StationBoard;
    using System;

    public interface IQueryService
    {
        StationCollection GetStations(string query);

        StationBoardRoot GetStationBoard(string id, DateTime dateTime);

        StationBoardRoot GetStationBoardByName(string name, DateTime dateTime);

        ConnectionCollection GetConnections(string fromStation, string toStation);

        ConnectionCollection GetConnections(string fromStation, string toStation, DateTime time, bool isArrivalTime);
    }
}