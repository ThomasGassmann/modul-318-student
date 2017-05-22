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
        /// Contains the cached location.
        /// </summary>
        private static SwissTransportGeoLocation cachedLocation;

        /// <summary>
        /// Contains the <see cref="GeoCoordinateWatcher"/>.
        /// </summary>
        private static readonly GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

        /// <summary>
        /// Executes, when the first instance of this class is created.
        /// </summary>
        static LocationQueryService()
        {
            LocationQueryService.watcher.StatusChanged += LocationQueryService.Watcher_StatusChanged;
            LocationQueryService.watcher.PositionChanged += LocationQueryService.Watcher_PositionChanged;
            LocationQueryService.watcher.Start();
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
            if (!LocationQueryService.watcher.Position.Location.IsUnknown)
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
            if (e.Status == GeoPositionStatus.Ready && !LocationQueryService.watcher.Position.Location.IsUnknown)
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
                Latitude = LocationQueryService.watcher.Position.Location.Latitude,
                Longitude = LocationQueryService.watcher.Position.Location.Longitude,
                Status = "success"
            };
        }
    }
}
