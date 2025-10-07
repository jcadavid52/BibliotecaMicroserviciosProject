using Microsoft.Extensions.Configuration;
using SistemaCuentas.Application.Dtos;
using SistemaCuentas.Application.Exceptions;
using SistemaCuentas.Application.Ports;
using SistemaCuentas.RefrehToken.Data;

namespace SistemaCuentas.RefrehToken
{
    public class RefreshTokenService(IConfiguration configuration) : IRefreshTokenService
    {
        private readonly AccessData accessData = new AccessData(configuration.GetConnectionString("Db")!.ToString());

        public async Task<string> AddAsync(string userId)
        {
            var refreshToken = await accessData.AddRefreshTokenAsync(userId);

            return refreshToken;
        }

        public async Task<RefreshTokenDto> GenerateAsync(string refreshToken)
        {
            var refreshTokenModel = await accessData.GetRefreshTokenByToken(refreshToken)
                ?? throw new NoAuthorizeException("No Autorizado");

            if(refreshTokenModel.IsRevoked || refreshTokenModel.ExpiresAt <= DateTime.UtcNow)
            {
                throw new NoAuthorizeException("No Autorizado");
            }

                await accessData.RevokeRefreshTokenAsync(refreshTokenModel.Token);

            var newRefreshToken = await accessData.AddRefreshTokenAsync(refreshTokenModel.UserId);

            return new RefreshTokenDto(
                newRefreshToken,
                refreshTokenModel.UserId,
                refreshTokenModel.ExpiresAt
                );
        }
    }
}
