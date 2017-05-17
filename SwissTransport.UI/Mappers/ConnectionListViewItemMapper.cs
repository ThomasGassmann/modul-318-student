namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Connection;
    using SwissTransport.UI.Mappers.Interfaces;
    using SwissTransport.UI.Properties;
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public class ConnectionListViewItemMapper : 
        IMapper<TransportConnection, ListViewItem>
    {
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
           var timeSpan = connection.Duration == null
                ? connection.To.ArrivalDateTime - connection.From.DepartureDateTime
                : TimeSpan.ParseExact(
                    connection.Duration.Replace('d', '.'),
                    "c",
                    CultureInfo.CurrentCulture);
            var timeSpanValue = $@"{(timeSpan.Days != 0 ? $"{timeSpan.Days.ToString()}d" : string.Empty)} {(timeSpan.Hours != 0 ? $"{timeSpan.Hours.ToString()}h" : string.Empty)} {(timeSpan.Minutes != 0 ? $"{timeSpan.Minutes.ToString()}m" : string.Empty)}";
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
