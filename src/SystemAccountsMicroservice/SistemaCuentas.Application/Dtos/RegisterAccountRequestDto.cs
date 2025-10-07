using System.ComponentModel.DataAnnotations;

namespace SistemaCuentas.Application.Dtos
{
    public record RegisterAccountRequestDto
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        public string FullName { get; init; } = string.Empty;

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        [RegularExpression("^(CC|TI|PA)$", ErrorMessage = "El tipo de documento solo puede ser 'CC', 'TI' o 'PA'")]
        public string DocumentType { get; init; } = string.Empty;

        [Required(ErrorMessage = "El documento es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El documento solo puede contener números")]
        public string Document { get; init; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Email { get; init; } = string.Empty;

        public string? Address { get; init; }

        [RegularExpression(@"^$|^\d{10,}$", ErrorMessage = "El número de teléfono debe tener al menos 10 dígitos y solo números")]
        public string? PhoneNumber { get; init; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener mínimo 6 caracteres")]
        public string Password { get; init; } = string.Empty;

        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; init; } = string.Empty;
    }
}
