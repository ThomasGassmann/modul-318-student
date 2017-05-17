namespace SwissTransport.UI.Mappers
{
    using System;
    using SwissTransport.Model.Station;
    using SwissTransport.UI.Mappers.Interfaces;
    using SwissTransport.UI.ViewModels;

    public class TransportStationComboboxItemMapper :
        IMapper<TransportStation, ComboboxItemViewModel<TransportStation>>
    {
        public ComboboxItemViewModel<TransportStation> Create(TransportStation source) =>
            new ComboboxItemViewModel<TransportStation>(source, f => f.Name);
    }
}
