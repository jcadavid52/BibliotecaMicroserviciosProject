using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCuentas.Application.Dtos;
using SistemaCuentas.Application.Ports;

namespace SistemaCuentas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(
        IAccountService accountService
        ) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto command)
        {
            var loginResult = await accountService.LoginAsync(command);

            return Ok(loginResult);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequestDto command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(command);
            }

            var createResult = await accountService.RegisterAsync(command);

            return Created("", new { createResult });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto command)
        {
            var refreshTokenResult = await accountService.RefreshTokenAsync(command);

            return Ok(refreshTokenResult);
        }
    }
}
