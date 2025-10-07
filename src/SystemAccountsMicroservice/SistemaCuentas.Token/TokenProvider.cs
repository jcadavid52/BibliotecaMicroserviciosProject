using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaCuentas.Application.Dtos;
using SistemaCuentas.Application.Ports;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaCuentas.Token
{
    public class TokenProvider(
        IConfiguration configuration
        ) : ITokenProvider
    {
        public string GenerateToken(ClaimsUserDto claimsUserDto)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, claimsUserDto.Id),
                new(ClaimTypes.Email, claimsUserDto.Email),
                new(ClaimTypes.Name, claimsUserDto.FullName),
            };

            foreach (var role in claimsUserDto.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApiSettings:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "tuDominio.com",
                audience: "tuDominio.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
