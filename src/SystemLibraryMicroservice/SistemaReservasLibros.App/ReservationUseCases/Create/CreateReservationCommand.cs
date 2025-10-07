using MediatR;
using SistemaReservasLibros.App.Dtos;

namespace SistemaReservasLibros.App.ReservationUseCases.Create
{
    public record CreateReservationCommand(
        DateTime StartDate,
        string UserId,
        List<CreateReservationRequestDto> ReservationBooks
        ) :IRequest<int>;
}
