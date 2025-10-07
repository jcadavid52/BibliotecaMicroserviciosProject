using MediatR;
using SistemaReservasLibros.App.Dtos;
using System.Text.Json.Serialization;

namespace SistemaReservasLibros.App.BookUseCases.Update
{
    public record UpdateBookCommand(
        string? Title,
        string? Author,
        int? Stock
        ):IRequest<UpdateBookResponseDto>
    {
        [JsonIgnore]
        public int Id { get; init; }
    }
}
