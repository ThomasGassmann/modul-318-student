namespace SwissTransport.DataAccess.Interfaces
{
    using SwissTransport.Model.Location;

    /// <summary>
    /// Defines the service to query the web API for the current user location.
    /// </summary>
    public interface ILocationQueryService
    {
        /// <summary>
        /// Calculates the current location by the IP address on the user's computer.
        /// </summary>
        /// <returns>Returns the location corresponding to the IP address.</returns>
        IPLocation GetCurrentLocation();
    }
}
