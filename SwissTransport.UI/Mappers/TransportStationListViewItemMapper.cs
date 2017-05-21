namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Windows.Forms;

    /// <summary>
    /// Maps the transport station to a list view item.
    /// </summary>
    public class TransportStationListViewItemMapper :
        IMapper<TransportStation, ListViewItem>
    {
        /// <inheritdoc />
        public ListViewItem Create(TransportStation source) =>
            new ListViewItem(source.Name)
            {
                Tag = source
            };
    }
}
