namespace SwissTransport.DataAccess
{
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Station;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines a service to get stations close to the current location.
    /// </summary>
    public class LocatableStationService : ILocatableStationService
    {
        /// <summary>
        /// Stores the service to get the location.
        /// </summary>
        private readonly ILocationQueryService locationQueryService;

        /// <summary>
        /// Stores the service to get the transportation data.
        /// </summary>
        private readonly IQueryService dataQueryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocatableStationService"/> class.
        /// </summary>
        /// <param name="locationQueryService">The service to get the location.</param>
        /// <param name="dataQueryService">The service to get the transportation data.</param>
        public LocatableStationService(
            ILocationQueryService locationQueryService,
            IQueryService dataQueryService)
        {
            this.locationQueryService = locationQueryService;
            this.dataQueryService = dataQueryService;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public TransportStation GetClosestStation() =>
            this.GetClosestStations().FirstOrDefault();
    }
}
