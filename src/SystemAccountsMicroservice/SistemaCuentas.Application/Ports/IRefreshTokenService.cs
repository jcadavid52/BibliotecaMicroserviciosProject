using SistemaCuentas.Application.Dtos;

namespace SistemaCuentas.Application.Ports
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenDto> GenerateAsync(string refreshToken);
        Task<string> AddAsync(string userId);
    }
}
