namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Connection;
    using SwissTransport.UI.Mappers.Interfaces;
    using SwissTransport.UI.Properties;
    using System.Windows.Forms;

    public class ConnectionListViewItemCreator : 
        IMapper<TransportConnection, ListViewItem>
    {
        public ListViewItem Create(
            TransportConnection connection)
        {
            var listViewItem = new ListViewItem(string.Empty);
            listViewItem.Tag = connection;
            listViewItem.SubItems.Add(
                connection.From.DepartureDateTime.ToString(Resources.ListViewDateTimeFormat));
            listViewItem.SubItems.Add(
                connection.To.ArrivalDateTime.ToString(Resources.ListViewDateTimeFormat));
            listViewItem.SubItems.Add(connection.Duration);
            listViewItem.SubItems.Add(string.IsNullOrEmpty(connection.From.Platform)
                ? Resources.Empty
                : connection.From.Platform);
            listViewItem.SubItems.Add(string.IsNullOrEmpty(connection.To.Platform)
                ? Resources.Empty
                : connection.To.Platform);
            return listViewItem;
        }
    }
}
