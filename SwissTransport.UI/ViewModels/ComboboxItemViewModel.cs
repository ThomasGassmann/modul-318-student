namespace SwissTransport.UI.ViewModels
{
    using System;

    public class ComboboxItemViewModel<T>
    {
        private readonly Func<T, string> getDisplayValue;

        public ComboboxItemViewModel(
            T value,
            Func<T, string> displayValue)
        {
            this.Value = value;
            this.getDisplayValue = displayValue;
        }

        public string DisplayText => getDisplayValue(this.Value);

        public T Value { get; private set; }

        public override string ToString() =>
            this.DisplayText;
    }
}
