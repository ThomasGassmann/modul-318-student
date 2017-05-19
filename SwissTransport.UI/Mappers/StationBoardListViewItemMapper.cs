namespace SwissTransport.UI.Mappers
{
    using Properties;
    using SwissTransport.DataAccess;
    using SwissTransport.Model.StationBoard;
    using SwissTransport.UI.ActionHandlers;
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public class StationBoardListViewItemMapper :
        IMapper<StationBoardRoot, IEnumerable<ListViewItem>>
    {
        public IEnumerable<ListViewItem> Create(StationBoardRoot source)
        {
            foreach (var entry in source.Entries)
            {
                var actionHandler = new ActionHandler(null);
                var connection = actionHandler.HandleFunc(() =>
                {
                    var connections = new TransportationQueryService().GetConnections(
                        source.Station.Id,
                        entry.To,
                        entry.Stop.Departure,
                        false);
                    return connections.ConnectionList.OrderBy(x => x.From.DepartureDateTime).First();
                });
                Thread.Sleep(1000);
                var listViewItem = new ListViewItem($"{entry.Operator} ({entry.Name})");
                listViewItem.SubItems.Add(entry.Stop.Departure.ToString("HH:mm"));
                listViewItem.SubItems.Add(entry.To);
                listViewItem.SubItems.Add(connection == null ? Resources.Empty : connection.To.ArrivalDateTime.ToString("HH:mm"));
                listViewItem.SubItems.Add(connection == null ? Resources.Empty : connection.GetDurationString());
                listViewItem.SubItems.Add(connection == null || string.IsNullOrEmpty(connection.From.Platform) ? Resources.Empty : connection.From.Platform);
                listViewItem.SubItems.Add(connection == null || string.IsNullOrEmpty(connection.To.Platform) ? Resources.Empty : connection.To.Platform);
                yield return listViewItem;
            }
        }
    }
}
