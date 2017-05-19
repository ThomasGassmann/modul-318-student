namespace SwissTransport.UI.Common.Interfaces
{
    using SwissTransport.Model.Station;
    using System.Collections.Generic;

    public interface ILocatableStationService
    {
        IEnumerable<TransportStation> GetClosestStations();

        TransportStation GetClosestStation();
    }
}
