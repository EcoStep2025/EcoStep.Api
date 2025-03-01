using EcoStep.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EcoStep.Api.Middleware
{
    public class FirebaseAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFirebaseAuthenticationService _authService;
        public FirebaseAuthenticationMiddleware(RequestDelegate next, IFirebaseAuthenticationService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Auth/signup") )
            {
                // Si es uno de esos endpoints, omitir la verificación de token
                await _next(context);
                return;
            }


            var authHeader = context.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token no proporcionado o inválido");
                return;
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            var uid = await _authService.VerifyTokenAsync(token);

            if (uid == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token inválido o expirado");
            }
            else
            {
                context.Items["User"] = uid;
                await _next(context);
            }
        }
    }
}
