namespace SwissTransport.DataAccess
{
    using Newtonsoft.Json;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Location;
    using System.Device.Location;
    using System.Net;

    /// <inheritdoc />
    public class LocationQueryService : ILocationQueryService
    {
        /// <summary>
        /// Contains the <see cref="GeoCoordinateWatcher"/>.
        /// </summary>
        private static readonly GeoCoordinateWatcher Watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

        /// <summary>
        /// Contains the cached location.
        /// </summary>
        private static SwissTransportGeoLocation cachedLocation;

        /// <summary>
        /// Initializes static members of the <see cref="LocationQueryService"/> class.
        /// Executes, when the first instance of this class is created.
        /// </summary>
        static LocationQueryService()
        {
            LocationQueryService.Watcher.StatusChanged += LocationQueryService.Watcher_StatusChanged;
            LocationQueryService.Watcher.PositionChanged += LocationQueryService.Watcher_PositionChanged;
            LocationQueryService.Watcher.Start();
        }

        /// <inheritdoc />
        public SwissTransportGeoLocation GetCurrentLocation()
        {
            if (LocationQueryService.cachedLocation != null)
            {
                return LocationQueryService.cachedLocation;
            }

            using (var webClient = new WebClient())
            {
                var locationJson = webClient.DownloadString("http://ip-api.com/json");
                return JsonConvert.DeserializeObject<SwissTransportGeoLocation>(locationJson);
            }
        }

        /// <summary>
        /// Sets the location, if the position has changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (!LocationQueryService.Watcher.Position.Location.IsUnknown)
            {
                LocationQueryService.SetLocation();
            }
        }

        /// <summary>
        /// Updates the locatin, if the watcher is ready.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready && !LocationQueryService.Watcher.Position.Location.IsUnknown)
            {
                LocationQueryService.SetLocation();
            }
        }

        /// <summary>
        /// Sets the current location.
        /// </summary>
        private static void SetLocation()
        {
            LocationQueryService.cachedLocation = new SwissTransportGeoLocation
            {
                Latitude = LocationQueryService.Watcher.Position.Location.Latitude,
                Longitude = LocationQueryService.Watcher.Position.Location.Longitude,
                Status = "success"
            };
        }
    }
}
