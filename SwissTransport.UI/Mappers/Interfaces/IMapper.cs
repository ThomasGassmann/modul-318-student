namespace SwissTransport.UI.Mappers.Interfaces
{
    public interface IMapper<TSource, TResult>
    {
        TResult Create(TSource source);
    }
}
