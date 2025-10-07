using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaCuentas.Application.Ports;
using SistemaCuentas.Identity.Data;
using SistemaCuentas.Identity.Services;

namespace SistemaCuentas.Identity
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddIdentity(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient(typeof(IAccountService), typeof(AccountService));

            var connectionString = configuration.GetConnectionString("Db")
                ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString));
            services.AddIdentityCore<ApplicationIdentity>(options => { })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddTokenProvider<EmailTokenProvider<ApplicationIdentity>>("Email");

            return services;
        }
    }
}
