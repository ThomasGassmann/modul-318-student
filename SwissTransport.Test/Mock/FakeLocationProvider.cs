namespace SwissTransport.Test.Mock
{
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Location;

    public class FakeLocationProvider : ILocationQueryService
    {
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
