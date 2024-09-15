namespace Cintruct.MvcUi.Middlewares
{
    public class CacheControlHandler
    {
        private readonly RequestDelegate _next;
        public CacheControlHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.Response.Headers["Expires"] = "-1";
            await _next(context);
        }
    }
}
