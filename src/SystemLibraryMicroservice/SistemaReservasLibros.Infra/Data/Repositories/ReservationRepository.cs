using Microsoft.EntityFrameworkCore;
using SistemaReservasLibros.Domain.Models;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.Infra.Data.Repositories
{
    [Repository]
    public class ReservationRepository(DataContext dataContext) : GenericRepository<Reservation>(dataContext), IReservationRepository
    {
        public async Task<IEnumerable<Reservation>> GetByIdUser(string userId)
        {
            return await Query().Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
