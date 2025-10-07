using MediatR;

namespace SistemaReservasLibros.App.BookUseCases.Delete
{
    public record DeleteBookCommand(List<int> Ids):IRequest;
}
