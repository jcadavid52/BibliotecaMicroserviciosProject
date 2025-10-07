using Microsoft.Extensions.DependencyInjection;
using SistemaCuentas.Application.Ports;

namespace SistemaCuentas.RefrehToken
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddServiceRefreshToken(
            this IServiceCollection services
            )
        {
            services.AddTransient(typeof(IRefreshTokenService), typeof(RefreshTokenService));

            return services;
        }
    }
}
