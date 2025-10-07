namespace SistemaCuentas.Application.Dtos
{
    public record ClaimsUserDto(
        string Id,
        string Email,
        string FullName,
        IEnumerable<string> Roles
        );
}
