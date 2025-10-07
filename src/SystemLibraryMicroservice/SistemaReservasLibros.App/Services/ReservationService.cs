using SistemaReservasLibros.App.Exceptions;
using SistemaReservasLibros.App.Extensions;
using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.App.Services
{
    [ApplicationService]
    public class ReservationService
    {
        public void ValidateRepeatedBooks(List<int> ids)
        {
            bool hasRepeatedBooks = ids.Count != ids.Distinct().Count();

            if (hasRepeatedBooks)
            {
                throw new ReservationBookException("Una reserva no puede contener libros repetidos");
            }
        }
        public void ValidateStockReservationBooks(IEnumerable<Book> books)
        {
            foreach(var book in books)
            {
                if (book.Stock <= 0)
                    throw new ReservationBookException($"El libro con id '{book.Id}' no tiene stock válido");
            }
        }

        public void DiscountStockBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                book.DescontarStock();
            }
        }

        public void ValidateTraslapeReservation(
            IEnumerable<Reservation> reservations,
            Reservation newReservation,
            string userId
            )
        {
            foreach(var existReservation in reservations)
            {
                bool traslape = existReservation.StartDate < newReservation.EndDate
                    && newReservation.StartDate < existReservation.EndDate
                    && newReservation.Status == "Activo";

                if (traslape)
                    throw new ReservationBookException($"Ya existe una reserva activa con las fechas" +
                        $" '{existReservation.StartDate.Date}' y '{existReservation.EndDate.Date}' para el usuario con id '{userId}'," +
                        $" indique una fecha diferente al traslape");
            }

        }

        public void ValidateReservationActiveByUser(IEnumerable<Reservation> reservations)
        {
            int cont = reservations.Where(r => r.Status == "Activo").Count();

            if (cont >= 2)
                throw new ReservationBookException("Se ha superado el límite de reservas activas por usuario");
        }
    }
}
