namespace SwissTransport.UI.Mappers.Interfaces
{
    /// <summary>
    /// Defines the mapper.
    /// </summary>
    /// <typeparam name="TSource">The source type to map from.</typeparam>
    /// <typeparam name="TResult">The result type to map to.</typeparam>
    public interface IMapper<TSource, TResult>
    {
        /// <summary>
        /// Converts type TSource to type TResult.
        /// </summary>
        /// <param name="source">The source to map.</param>
        /// <returns>The mapped result.</returns>
        TResult Create(TSource source);
    }
}
