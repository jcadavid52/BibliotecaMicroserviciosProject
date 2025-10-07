using SistemaCuentas.Application.Dtos;

namespace SistemaCuentas.Application.Ports
{
    public interface ITokenProvider
    {
        string GenerateToken(ClaimsUserDto claimsUserDto);
    }
}
