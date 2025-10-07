using Microsoft.AspNetCore.Identity;
using SistemaCuentas.Application.Dtos;
using SistemaCuentas.Application.Exceptions;
using SistemaCuentas.Application.Ports;
using SistemaCuentas.Identity.Data;

namespace SistemaCuentas.Identity.Services
{
    public class AccountService(
        UserManager<ApplicationIdentity> userManager,
        ITokenProvider tokenProvider,
        IRefreshTokenService refreshTokenService
        ) : IAccountService
    {
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var applicationIdentity = await userManager.FindByEmailAsync(loginRequestDto.Username) ??
                throw new NoAuthorizeException("Clave o usuario inválido");

            var passwordChecked = await userManager.CheckPasswordAsync(applicationIdentity, loginRequestDto.Password);

            if(!passwordChecked)
                throw new NoAuthorizeException("Clave o usuario inválido");

            var roles = await userManager.GetRolesAsync(applicationIdentity);

            if (roles.Count <= 0)
                throw new NoAssignRoleException("El usuario no tiene roles asignados");

            var claimsUser = new ClaimsUserDto(
                applicationIdentity.Id,
                applicationIdentity.Email!,
                applicationIdentity.FullName,
                roles
                );
            
            var accessToken = tokenProvider.GenerateToken(claimsUser);

            var userDto = new UserDto(
                    applicationIdentity.Id,
                    applicationIdentity.FullName,
                    applicationIdentity.DocumentType,
                    applicationIdentity.Document,
                    applicationIdentity.Email!,
                    applicationIdentity.Address,
                    applicationIdentity.PhoneNumber!
                    );

            var refreshToken = await refreshTokenService.AddAsync(applicationIdentity.Id);
            return new LoginResponseDto(
                userDto,
                accessToken,
                refreshToken
                );
        }

        public async Task<UserDto> RegisterAsync(RegisterAccountRequestDto register)
        {
            var applicationIdentity = new ApplicationIdentity
            {
                Email = register.Email,
                UserName = register.Email,
                PhoneNumber = register.PhoneNumber,
                Address = register.Address ?? "No aplica",
                FullName = register.FullName,
                DocumentType = register.DocumentType,
                Document = register.Document
            };

            var resultCreate = await userManager.CreateAsync(applicationIdentity,register.ConfirmPassword);

            if (!resultCreate.Succeeded)
            {
               foreach(var error in resultCreate.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        throw new DuplicateUserNameException($"Error:{error.Code} El usuario '{register.Email}' ya existe");
                    }else if (error.Code == "PasswordRequiresNonAlphanumeric" || error.Code == "PasswordRequiresDigit" || error.Code == "PasswordRequiresUpper")
                    {
                        throw new InvalidPasswordException("La contraseña no cumple con la seguridad mínima: Debe contener Mayúsculas, Dígitos y Alfanuméricos");
                    }
                    else
                    {
                        throw new InternalRegisterException($"Error al registrarse: {error.Description}");
                    }
                }
            }

            var addRoleResult = await userManager.AddToRoleAsync(applicationIdentity, "Usuario");

            if (!addRoleResult.Succeeded)
            {
                throw new InternalAddToRoleException($"Error inesperado: {addRoleResult.Errors.FirstOrDefault()!.Description}");
            }

            return new UserDto(
                applicationIdentity.Id,
                applicationIdentity.FullName,
                applicationIdentity.DocumentType,
                applicationIdentity.Document,
                applicationIdentity.Email,
                applicationIdentity.Address,
                applicationIdentity.PhoneNumber ?? "No aplica"
                );
        }

        public async Task<RefreshTokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto refreshTokenRequest)
        {
            var refreshTokenResult = await refreshTokenService.GenerateAsync(refreshTokenRequest.RefreshToken);

            var applicationIdentity = await userManager.FindByIdAsync(refreshTokenResult.UserId) ??
                throw new NoAuthorizeException("No Autorizado");

            var roles = await userManager.GetRolesAsync(applicationIdentity);

            var claimsUserDto = new ClaimsUserDto(
                applicationIdentity.Id,
                applicationIdentity.Email!,
                applicationIdentity.FullName,
                roles
                );

            var accessToken = tokenProvider.GenerateToken(claimsUserDto);

            return new RefreshTokenResponseDto(
                refreshTokenResult.Token,
                accessToken,
                refreshTokenResult.ExpiresAt
                );
        }
    }
}
