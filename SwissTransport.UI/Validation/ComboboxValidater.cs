namespace SwissTransport.UI.Validation
{
    using SwissTransport.Model.Station;
    using SwissTransport.UI.ViewModels;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Contains the validation logic for comboboxes.
    /// </summary>
    public static class ComboboxValidater
    {
        /// <summary>
        /// Checks whether all comboxboes contain a valid <see cref="ComboboxItemViewModel{T}"/>, 
        /// where T is <see cref="TransportStation"/>.
        /// </summary>
        /// <param name="comboBoxes">The comboboxes to check.</param>
        /// <returns>Returns true, if all comboxboxes contain valid data. Otherwise false.</returns>
        public static bool ContainValidLocations(params ComboBox[] comboBoxes) =>
            comboBoxes
                .Select(x => x.SelectedItem)
                .All(x => x != null && x is ComboboxItemViewModel<TransportStation>);
    }
}
