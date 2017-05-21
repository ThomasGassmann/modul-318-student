namespace SwissTransport.UI.ViewModels
{
    using System;

    /// <summary>
    /// Defines a view model for the <see cref="ComboBox"/>.
    /// </summary>
    /// <typeparam name="T">The type the view model should contain.</typeparam>
    public class ComboboxItemViewModel<T>
    {
        /// <summary>
        /// Stores the function to get the display value from the value.
        /// </summary>
        private readonly Func<T, string> getDisplayValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboboxItemViewModel{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="displayValue">The function of the display value.</param>
        public ComboboxItemViewModel(
            T value,
            Func<T, string> displayValue)
        {
            this.Value = value;
            this.getDisplayValue = displayValue;
        }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        public string DisplayText => this.getDisplayValue(this.Value);

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value { get; private set; }

        /// <inheritdoc />
        public override string ToString() =>
            this.DisplayText;
    }
}
