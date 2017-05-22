namespace SwissTransport.Test.Mock
{
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Location;

    /// <summary>
    /// Provides a fake location.
    /// </summary>
    public class FakeLocationProvider : ILocationQueryService
    {
        /// <summary>
        /// Gets the current location of Uffikon.
        /// </summary>
        /// <returns>The location of Uffikon.</returns>
        public SwissTransportGeoLocation GetCurrentLocation()
        {
            return new SwissTransportGeoLocation
            {
                Status = "success",
                Latitude = 47.2104625,
                Longitude = 8.0169895
            };
        }
    }
}
