namespace SistemaReservasLibros.Domain.Models
{
    public class ReservationBook
    {
        public int BookId { get; private set; }

        public Book Book { get; private set; } = default!;

        public int ReservationId { get; private set; }

        public Reservation Reservation { get; private set; } = default!;

        public static ReservationBook Create(int idBook)
        {
            ArgumentNullException.ThrowIfNull(idBook, nameof(idBook));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(idBook);

            return new ReservationBook
            {
                BookId = idBook
            };
        }
    }
}
