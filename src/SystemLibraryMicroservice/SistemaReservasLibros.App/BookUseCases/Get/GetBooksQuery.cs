using MediatR;
using SistemaReservasLibros.App.Dtos;

namespace SistemaReservasLibros.App.BookUseCases.Get
{
    public record GetBooksQuery(
        string? Title,
        int? PageSize,
        int? PageNumber
        ):IRequest<IEnumerable<GetBooksResponseDto>>;
}
