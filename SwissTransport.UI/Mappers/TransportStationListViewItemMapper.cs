namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Windows.Forms;

    public class TransportStationListViewItemMapper :
        IMapper<TransportStation, ListViewItem>
    {
        public ListViewItem Create(TransportStation source) =>
            new ListViewItem(source.Name)
            {
                Tag = source
            };
    }
}
