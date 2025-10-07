using System.ComponentModel.DataAnnotations;

namespace SistemaCuentas.Application.Dtos
{
    public record RefreshTokenRequestDto
    {
        [Required(ErrorMessage = "El refresh token es obligatorio")]
        public string RefreshToken { get; init; } = string.Empty;
    }
}
