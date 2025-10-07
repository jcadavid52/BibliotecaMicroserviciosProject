using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SistemaReservasLibros.Domain.Ports;
using SistemaReservasLibros.Infra.Data;
using System.Text;

namespace SistemaReservasLibros.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            var connectionString = configuration.GetConnectionString("db")
            ?? throw new ArgumentNullException(nameof(configuration));

            //Agrego ef core
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            var _repositories = AppDomain.CurrentDomain.GetAssemblies()
          .Where(assembly =>
          {
              return assembly.FullName is null || assembly.FullName.Contains("Infra", StringComparison.OrdinalIgnoreCase);
          })
          .SelectMany(assembly => assembly.GetTypes())
          .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(RepositoryAttribute)));

            foreach (var repository in _repositories)
            {
                foreach (var typeInterface in repository.GetInterfaces())
                {
                    services.AddTransient(typeInterface, repository);
                }
            }

            //agrego autenticación
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "tuDominio.com",
                    ValidAudience = "tuDominio.com",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("clavesecreta2025*636363porfavordameunempleo2025"))
                };
            });

            return services;
        }
    }
}
