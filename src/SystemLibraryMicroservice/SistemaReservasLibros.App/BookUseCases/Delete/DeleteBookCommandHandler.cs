using MediatR;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.App.BookUseCases.Delete
{
    public class DeleteBookCommandHandler(
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteBookCommand>
    {
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetManyByIdsAsync(request.Ids);
            bookRepository.RemoveMany(books);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
