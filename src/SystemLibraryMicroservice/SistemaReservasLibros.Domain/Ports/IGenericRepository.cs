namespace SistemaReservasLibros.Domain.Ports
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();

        Task CreateAsync(T entity);
    }
}
