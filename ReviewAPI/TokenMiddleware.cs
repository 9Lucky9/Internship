using ReviewAPI.Authentication;
using ReviewAPI.Repository;

namespace ReviewAPI
{
    public class TokenMiddleware
    {
        private RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUser iUser)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = TokenHelper.ValidateToken(token);
            if (userId != null)
            {
                context.Items["User"] = iUser.GetUser((int)userId);
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
