namespace SistemaReservasLibros.Domain.Dtos
{
    public record QueryBookDto(
        string? Title,
        int? PageSize,
        int? PageNumber,
        bool IncludeReservations = false
        );
}
