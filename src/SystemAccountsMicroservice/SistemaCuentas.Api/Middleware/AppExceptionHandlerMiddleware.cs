using Azure.Core;
using SistemaCuentas.Application.Exceptions;
using System.Net;

namespace SistemaCuentas.Api.Middleware
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;
        private static readonly Dictionary<Type, HttpStatusCode> StatusCodes = new()
        {
             { typeof(DuplicateUserNameException), HttpStatusCode.Conflict },
             { typeof(NoAuthorizeException), HttpStatusCode.Unauthorized },
             { typeof(InternalRegisterException), HttpStatusCode.InternalServerError },
             { typeof(InternalAddToRoleException), HttpStatusCode.InternalServerError },
             { typeof(NoAssignRoleException), HttpStatusCode.InternalServerError },
             { typeof(InvalidPasswordException), HttpStatusCode.BadRequest },
        };

        public AppExceptionHandlerMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                object response;

                response = new
                {
                    message = ex.Message
                };

                var result = System.Text.Json.JsonSerializer.Serialize(response);
                context.Response.ContentType = ContentType.ApplicationJson.ToString();
                context.Response.StatusCode = GetStatusCodeForException(ex);
                await context.Response.WriteAsync(result);
            }

        }

        private static int GetStatusCodeForException(Exception ex)
        {
            return StatusCodes.TryGetValue(ex.GetType(), out var statusCode)
                ? (int)statusCode
                : (int)HttpStatusCode.InternalServerError;
        }
    }
}
