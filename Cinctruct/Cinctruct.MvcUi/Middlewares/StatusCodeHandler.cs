namespace Cintruct.MvcUi.Middlewares
{
	/// <summary>
	/// A middleware class for handling HTTP status codes and redirecting to specific pages based on the status code.
	/// </summary>
	public class StatusCodeHandler
    {
        private readonly RequestDelegate _next;

		/// <summary>
		/// Initializes a new instance of the <see cref="StatusCodeHandler"/> class with the specified request delegate.
		/// </summary>
		/// <param name="next">The next middleware in the request pipeline.</param>
		public StatusCodeHandler(RequestDelegate next)
        {
            _next = next;
        }

		/// <summary>
		/// Invokes the middleware to handle HTTP status codes and redirect to appropriate pages based on the status code.
		/// </summary>
		/// <param name="context">The HTTP context for the current request.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
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

		/// <summary>
		/// Redirects the response to the specified URL.
		/// </summary>
		/// <param name="context">The HTTP context for the current request.</param>
		/// <param name="url">The URL to redirect to.</param>
		private void RedirectTo(HttpContext context, string url)
        {
            context.Response.Redirect(url);
        }
    }
}
