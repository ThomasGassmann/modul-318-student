namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Connection;
    using SwissTransport.UI.Mappers.Interfaces;
    using SwissTransport.UI.Properties;
    using System.Windows.Forms;

    /// <summary>
    /// Maps transport connections to list view items.
    /// </summary>
    public class ConnectionListViewItemMapper : 
        IMapper<TransportConnection, ListViewItem>
    {
        /// <inheritdoc />
        public ListViewItem Create(
            TransportConnection connection)
        {
            var listViewItem = new ListViewItem(string.IsNullOrEmpty(connection.From.RealtimeAvailability)
                ? Resources.Empty
                : connection.From.RealtimeAvailability);
            listViewItem.Tag = connection;
            listViewItem.SubItems.Add(
                connection.From.DepartureDateTime.ToString(Resources.ListViewDateTimeFormat));
            listViewItem.SubItems.Add(
                connection.To.ArrivalDateTime.ToString(Resources.ListViewDateTimeFormat));
            var timeSpanValue = connection.GetDurationString();
            listViewItem.SubItems.Add(timeSpanValue);
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
