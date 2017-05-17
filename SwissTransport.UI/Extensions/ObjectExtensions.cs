namespace System
{
    using SwissTransport.UI.Mappers.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource source)
        {
            var mappers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x
                    .GetInterfaces()
                    .Contains(typeof(IMapper<TSource, TResult>)));
            if (mappers.Any())
            {
                throw new InvalidOperationException("No Mapper specified.");
            }

            var mapper = (IMapper<TSource, TResult>)Activator.CreateInstance(mappers.Single());
            return mapper.Create(source);
        }

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
