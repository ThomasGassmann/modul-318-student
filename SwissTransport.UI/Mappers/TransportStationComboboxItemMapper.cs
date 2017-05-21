namespace SwissTransport.UI.Mappers
{
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Mappers.Interfaces;
    using SwissTransport.UI.ViewModels;
    
    /// <summary>
    /// Maps the transport station to a comboxbox view model.
    /// </summary>
    public class TransportStationComboboxItemMapper :
        IMapper<TransportStation, ComboboxItemViewModel<TransportStation>>
    {
        /// <inheritdoc />
        public ComboboxItemViewModel<TransportStation> Create(TransportStation source) =>
            new ComboboxItemViewModel<TransportStation>(source, f => f.Name);
    }
}
