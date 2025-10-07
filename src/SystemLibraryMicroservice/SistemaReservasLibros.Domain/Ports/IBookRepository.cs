using SistemaReservasLibros.Domain.Dtos;
using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.Domain.Ports
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAsync(QueryBookDto query);

        Task<Book?> GetByIdAsync(int id);

        Task<IEnumerable<Book>> GetManyByIdsAsync(List<int> ids);

        void RemoveMany(IEnumerable<Book> books);
    }
}
