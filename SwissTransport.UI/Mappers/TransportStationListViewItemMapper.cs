namespace SwissTransport.UI.Mappers
{
    using SwissTransport.DataAccess;
    using SwissTransport.DataAccess.Interfaces;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Mappers.Interfaces;
    using System;
    using System.Device.Location;
    using System.Windows.Forms;

    /// <summary>
    /// Maps the transport station to a list view item.
    /// </summary>
    public class TransportStationListViewItemMapper :
        IMapper<TransportStation, ListViewItem>
    {
        /// <summary>
        /// Contains the location query service.
        /// </summary>
        private static readonly ILocationQueryService locationQueryService = new LocationQueryService();

        /// <summary>
        /// Contains the current location.
        /// </summary>
        private static GeoCoordinate currentLocation;

        /// <summary>
        /// Runs at the first initialization of the current class.
        /// </summary>
        static TransportStationListViewItemMapper()
        {
            var location = TransportStationListViewItemMapper.locationQueryService.GetCurrentLocation();
            TransportStationListViewItemMapper.currentLocation = 
                new GeoCoordinate(location.Latitude, location.Longitude);
        }

        /// <inheritdoc />
        public ListViewItem Create(TransportStation source)
        {
            var listViewItem = new ListViewItem(source.Name)
            {
                Tag = source
            };
            var location = new GeoCoordinate(
                source.Coordinate.XCoordinate,
                source.Coordinate.YCoordinate);
            if (TransportStationListViewItemMapper.currentLocation.IsUnknown)
            {
                listViewItem.SubItems.Add("Unbekannt");
            }
            else
            {
                var distance = location.GetDistanceTo(
                    TransportStationListViewItemMapper.currentLocation);
                listViewItem.SubItems.Add($"{Math.Round(distance / 1000, 0)} km");
            }
            return listViewItem;
        }
    }
}
