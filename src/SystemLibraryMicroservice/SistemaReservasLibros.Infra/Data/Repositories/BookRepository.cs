using Microsoft.EntityFrameworkCore;
using SistemaReservasLibros.Domain.Dtos;
using SistemaReservasLibros.Domain.Models;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.Infra.Data.Repositories
{
    [Repository]
    public class BookRepository(DataContext dataContext) : GenericRepository<Book>(dataContext), IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllAsync(QueryBookDto query)
        {
            var books = Query();

            if (!string.IsNullOrEmpty(query.Title))
                books = books.Where(b => b.Title.Contains(query.Title));

            if (query.IncludeReservations)
                books = books.Include(book => book.ReservationBooks);

            if (query.PageSize.HasValue && query.PageNumber.HasValue)
            {
                books = books
                .Skip((query.PageNumber.Value - 1) * query.PageSize.Value)
                .Take(query.PageSize.Value);
            }

            return await books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> GetManyByIdsAsync(List<int> ids)
        {
            return await Query()
                .Where(book => ids.Contains(book.Id))
                .ToListAsync();
        }

        public void RemoveMany(IEnumerable<Book> books)
        {
            dataContext.Set<Book>().RemoveRange(books);
        }
    }
}
