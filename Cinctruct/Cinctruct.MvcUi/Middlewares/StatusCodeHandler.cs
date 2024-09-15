namespace Cintruct.MvcUi.Middlewares
{
    public class StatusCodeHandler
    {
        private readonly RequestDelegate _next;
        public StatusCodeHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            var statusCode = context.Response.StatusCode;
            var pathBase = context.Request.PathBase;
            switch (statusCode)
            {
                case 401:
                case 403:
                    RedirectTo(context, pathBase + "/Utilities/UnAuthorizePage");
                    break;
                case 404:
                    RedirectTo(context, pathBase + "/Utilities/NotFoundPage");
                    break;
                case 400:
                case 500:
                    RedirectTo(context, pathBase + "/Utilities/ErrorPage");
                    break;
            }
        }

        private void RedirectTo(HttpContext context, string url)
        {
            context.Response.Redirect(url);
        }
    }
}
