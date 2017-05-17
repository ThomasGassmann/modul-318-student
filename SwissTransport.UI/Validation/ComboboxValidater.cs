namespace SwissTransport.UI.Validation
{
    using SwissTransport.UI.ViewModels;
    using System.Linq;
    using SwissTransport.Model.Station;
    using System.Windows.Forms;

    public static class ComboboxValidater
    {
        public static bool ContainValidLocations(params ComboBox[] comboBoxes) =>
            comboBoxes
                .Select(x => x.SelectedItem)
                .All(x => x != null && x is ComboboxItemViewModel<TransportStation>);
    }
}
