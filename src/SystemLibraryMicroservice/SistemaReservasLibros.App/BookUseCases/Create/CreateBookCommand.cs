using MediatR;

namespace SistemaReservasLibros.App.BookUseCases.Create
{
    public record CreateBookCommand(
        string Title,
        string Author,
        int Stock
    ):IRequest<int>;
}
