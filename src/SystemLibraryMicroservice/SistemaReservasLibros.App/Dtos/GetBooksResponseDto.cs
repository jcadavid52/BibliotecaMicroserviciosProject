namespace SistemaReservasLibros.App.Dtos
{
    public record GetBooksResponseDto(
        int Id,
        string Title,
        string Author,
        string Status
        );
}
