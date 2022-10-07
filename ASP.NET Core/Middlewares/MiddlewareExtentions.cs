namespace ASP.NET_Core.Middlewares
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseLogginMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogginMiddleware>();
        }
    }
}