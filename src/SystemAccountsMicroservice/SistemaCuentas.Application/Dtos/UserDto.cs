namespace SistemaCuentas.Application.Dtos
{
    public record UserDto(
        string Id,
        string FullName,
        string DocumentType,
        string Document,
        string Email,
        string Address,
        string PhoneNumber
        );
}
