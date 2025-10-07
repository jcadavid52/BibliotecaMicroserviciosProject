using SistemaCuentas.Application.Dtos;

namespace SistemaCuentas.Application.Ports
{
    public interface IAccountService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);

        Task<UserDto> RegisterAsync(RegisterAccountRequestDto register);

        Task<RefreshTokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest);
    }
}
