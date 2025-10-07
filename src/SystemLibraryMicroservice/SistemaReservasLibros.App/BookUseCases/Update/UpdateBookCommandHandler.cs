using MediatR;
using SistemaReservasLibros.App.Dtos;
using SistemaReservasLibros.App.Exceptions;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.App.BookUseCases.Update
{
    public class UpdateBookCommandHandler(
        IBookRepository bookRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateBookCommand, UpdateBookResponseDto>
    {
        public async Task<UpdateBookResponseDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await bookRepository.GetByIdAsync(request.Id) ??
                throw new NoFoundException($"No se encontró libro con id '{request.Id}'");

            book.Update(
                request.Title,
                request.Author,
                request.Stock
                );

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateBookResponseDto(
                book.Id,
                book.Title,
                book.Autor,
                book.Stock,
                book.Stock >= 1 ? "Disponible" : "Agotado"
                );
        }
    }
}
