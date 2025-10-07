using SistemaReservasLibros.Domain.Abstractions;

namespace SistemaReservasLibros.Domain.Models
{
    public class Reservation:DomainEntity<int>
    {
        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public string Status { get; private set; } = default!;

        public string UserId { get; private set; } = default!;

        public ICollection<ReservationBook> ReservationBooks { get; private set; } = [];

        public static Reservation Create(
            DateTime startDate,
            List<ReservationBook> reservationBooks,
            string userId
            )
        {
            if (reservationBooks.Count <= 0)
                throw new ArgumentException("La reserva debe tener por lo menos un libro");

            if (startDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("La fecha de inicio de reserva no puede ser menor al día actual");

            return new Reservation
            {
                StartDate = startDate,
                EndDate = startDate.AddDays(7),
                Status = "Activo",
                ReservationBooks = reservationBooks,
                UserId = userId
            };
        }
    }
}
