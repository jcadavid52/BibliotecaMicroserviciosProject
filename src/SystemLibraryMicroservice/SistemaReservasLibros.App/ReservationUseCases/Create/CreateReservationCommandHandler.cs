using MediatR;
using SistemaReservasLibros.App.Services;
using SistemaReservasLibros.Domain.Models;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.App.ReservationUseCases.Create
{
    public class CreateReservationCommandHandler(
        IReservationRepository reservationRepository,
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork,
        ReservationService reservationService
        ) : IRequestHandler<CreateReservationCommand,int>
    {
        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            //obtiene ids de request
            List<int> ids = request.ReservationBooks.Select(rb => rb.BookId).ToList();
            //valida que no haya ids repetidos
            reservationService.ValidateRepeatedBooks(ids);

            //obtiene libros que cumplan con los ids del request
            var books = await bookRepository.GetManyByIdsAsync(ids);
            //valida que los stock de cada libro esten disponibles
            reservationService.ValidateStockReservationBooks(books);

            //convierte los request ids book en reservation book para crearlos con su lista de libros
            List<ReservationBook> reservationBooks  = request.ReservationBooks.Select(x => ReservationBook.Create(x.BookId)).ToList();

            var reservation = Reservation.Create(
                request.StartDate,
                reservationBooks,
                request.UserId
                );

            //valida que no haya una reserva activa en el traslape de fecha inicio - fecha fin por el id usuario
            var reservations = await reservationRepository.GetByIdUser(request.UserId);
            reservationService.ValidateTraslapeReservation(reservations, reservation,request.UserId);

            //valida que un usuario no tenga mas de 2 reservas activas
            reservationService.ValidateReservationActiveByUser(reservations);

            await reservationRepository.CreateAsync(reservation);

            //descuenta el stock de cada libro validado
            reservationService.DiscountStockBooks(books);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return reservation.Id;
        }
    }
}
