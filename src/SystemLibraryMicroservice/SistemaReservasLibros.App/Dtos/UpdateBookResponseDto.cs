namespace SistemaReservasLibros.App.Dtos
{
    public record UpdateBookResponseDto(
        int Id,
        string Title,
        string Author,
        int Stock,
        string Status
        );
}
