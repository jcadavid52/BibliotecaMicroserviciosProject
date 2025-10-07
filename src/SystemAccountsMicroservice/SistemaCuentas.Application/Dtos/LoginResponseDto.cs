namespace SistemaCuentas.Application.Dtos
{
    public record LoginResponseDto(
        UserDto User,
        string AccessToken,
        string refreshToken
        );
}
