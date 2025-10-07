using System.ComponentModel.DataAnnotations;

namespace SistemaCuentas.Application.Dtos
{
    public record LoginRequestDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Username { get; init; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; init; } = string.Empty;
    }
}
