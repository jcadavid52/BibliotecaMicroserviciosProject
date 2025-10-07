using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.Infra.Data.Repositories
{
    public class GenericRepository<T>(DataContext dataContext) : IGenericRepository<T> where T : class
    {
        public IQueryable<T> Query()
        {
            return dataContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dataContext.Set<T>().AddAsync(entity);
        }
    }
}
