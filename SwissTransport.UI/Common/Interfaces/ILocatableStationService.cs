namespace SwissTransport.UI.Common.Interfaces
{
    using SwissTransport.Model.Station;
    using System.Collections.Generic;

    /// <summary>
    /// Defines an interface to get stations close to the current location.
    /// </summary>
    public interface ILocatableStationService
    {
        /// <summary>
        /// Gets all stations near the current <see cref="TransportStation"/>.
        /// </summary>
        /// <returns>Returns the <see cref="TransportStation"/> found.</returns>
        IEnumerable<TransportStation> GetClosestStations();

        /// <summary>
        /// Returns the closest loation.
        /// </summary>
        /// <returns>The closest <see cref="TransportStation"/>.</returns>
        TransportStation GetClosestStation();
    }
}
