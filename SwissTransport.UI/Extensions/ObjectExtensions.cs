namespace System
{
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Contains all methods to extend <see cref="Object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Maps <see cref="{TSource}"/> to <see cref="{TResult}"/>. Throws an <see cref="InvalidOperationException"/>, 
        /// if there's no mapper defined for the given types.
        /// </summary>
        /// <typeparam name="TSource">The type to map from.</typeparam>
        /// <typeparam name="TResult">The type to map to.</typeparam>
        /// <param name="source">The source type to map to the result type.</param>
        /// <returns>Returns the result type.</returns>
        public static TResult Map<TSource, TResult>(this TSource source)
        {
            var mappers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x
                    .GetInterfaces()
                    .Contains(typeof(IMapper<TSource, TResult>)));
            if (!mappers.Any())
            {
                throw new InvalidOperationException("No Mapper specified.");
            }

            var mapper = (IMapper<TSource, TResult>)Activator.CreateInstance(mappers.Single());
            return mapper.Create(source);
        }

        /// <summary>
        /// Maps all items in a collection to a result type.
        /// </summary>
        /// <typeparam name="TSource">The type to map from.</typeparam>
        /// <typeparam name="TResult">The type to map to.</typeparam>
        /// <param name="source">The source collection to map.</param>
        /// <returns>Returns the mapped collection.</returns>
        public static IEnumerable<TResult> MapCollection<TSource, TResult>(
            this IEnumerable<TSource> source)
        {
            foreach (var item in source)
            {
                yield return item.Map<TSource, TResult>();
            }
        }
    }
}
