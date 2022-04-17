using ReviewAPI.Authentication;

namespace ReviewAPI
{
    public class TokenMiddleware
    {
        private RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IAuthentication Authentication)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = TokenHelper.ValidateToken(token);
            if (userId != null)
            {
                context.Items["User"] = Authentication.GetUser((int)userId);
            }

            await _next(context);
        }
    }

    public static class TokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMiddleware>();
        }
    }
}
