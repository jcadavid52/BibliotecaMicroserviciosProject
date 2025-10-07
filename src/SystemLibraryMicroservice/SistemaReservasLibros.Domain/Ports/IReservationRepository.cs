using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.Domain.Ports
{
    public interface IReservationRepository:IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetByIdUser(string userId);
    }
}
