namespace SistemaCuentas.Application.Dtos
{
    public record RefreshTokenResponseDto(
        string RefreshToken,
        string AccessToken,
        DateTime ExpiresAt
        );
}
