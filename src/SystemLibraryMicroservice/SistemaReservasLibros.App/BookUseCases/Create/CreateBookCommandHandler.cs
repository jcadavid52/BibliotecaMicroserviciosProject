using MediatR;
using SistemaReservasLibros.Domain.Models;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.App.BookUseCases.Create
{
    public class CreateBookCommandHandler(
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateBookCommand, int>
    {
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = Book.Create(
                request.Title.Trim(),
                request.Author.Trim(),
                request.Stock
                );

            await bookRepository.CreateAsync(book);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}
