namespace SwissTransport.DataAccess
{
    public interface ITransport
    {
        Stations GetStations(string query);

        StationBoardRoot GetStationBoard(string station, string id);

        ConnectionCollection GetConnections(string fromStation, string toStattion);
    }
}