namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.StationBoard;
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class StationBoardListViewItemMapper :
        IMapper<StationBoardRoot, IEnumerable<ListViewItem>>
    {
        public IEnumerable<ListViewItem> Create(StationBoardRoot source)
        {
            foreach (var entry in source.Entries)
            {
                var listViewItem = new ListViewItem(entry.Operator);
                listViewItem.SubItems.Add(entry.Name);
                yield return listViewItem;
            }
        }
    }
}
