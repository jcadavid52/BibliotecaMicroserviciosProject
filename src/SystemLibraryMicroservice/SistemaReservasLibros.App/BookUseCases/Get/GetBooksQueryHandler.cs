using MediatR;
using SistemaReservasLibros.App.Dtos;
using SistemaReservasLibros.Domain.Dtos;
using SistemaReservasLibros.Domain.Ports;

namespace SistemaReservasLibros.App.BookUseCases.Get
{
    public class GetBooksQueryHandler(
        IBookRepository bookRepository
        ):IRequestHandler<GetBooksQuery,IEnumerable<GetBooksResponseDto>>
    {
        public async Task<IEnumerable<GetBooksResponseDto>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
        {
            var books = await bookRepository.GetAllAsync(
                new QueryBookDto(query.Title,query.PageSize,query.PageNumber));

            var booksDto = books.Select(book =>
            {
                string status;
                if (book.Stock >= 1)
                {
                    status = "Disponible";
                }
                else
                {
                    status = "Agotado";
                }

                return new GetBooksResponseDto(
                    book.Id,
                    book.Title,
                    book.Autor,
                    status
                    );
            });

            return booksDto;
        }
    }
}
