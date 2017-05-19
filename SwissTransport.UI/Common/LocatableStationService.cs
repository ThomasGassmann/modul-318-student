namespace SwissTransport.UI.Common
{
    using SwissTransport.DataAccess;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Common.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class LocatableStationService : ILocatableStationService
    {
        private readonly ILocationQueryService locationQueryService;

        private readonly IQueryService dataQueryService;

        public LocatableStationService(
            ILocationQueryService locationQueryService,
            IQueryService dataQueryService)
        {
            this.locationQueryService = locationQueryService;
            this.dataQueryService = dataQueryService;
        }

        public IEnumerable<TransportStation> GetClosestStations()
        {
            var currentLocation = this.locationQueryService.GetCurrentLocation();
            if (!currentLocation.Success)
            {
                return null;
            }

            var stationsClose = this.dataQueryService.GetStationsNear(
                currentLocation.Latitude,
                currentLocation.Longitude);
            return stationsClose.StationList;
        }

        public TransportStation GetClosestStation() =>
            this.GetClosestStations().FirstOrDefault();
    }
}
