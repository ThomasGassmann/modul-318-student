namespace SwissTransport.DataAccess
{
    using SwissTransport.Model.Location;

    public interface ILocationQueryService
    {
        IPLocation GetCurrentLocation();
    }
}
