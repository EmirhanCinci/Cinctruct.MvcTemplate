namespace Cintruct.MvcUi.Middlewares
{
	/// <summary>
	/// A middleware class for controlling HTTP cache headers to prevent caching of responses.
	/// </summary>
	public class CacheControlHandler
    {
        private readonly RequestDelegate _next;

		/// <summary>
		/// Initializes a new instance of the <see cref="CacheControlHandler"/> class with the specified request delegate.
		/// </summary>
		/// <param name="next">The next middleware in the request pipeline.</param>
		public CacheControlHandler(RequestDelegate next)
        {
            _next = next;
        }

		/// <summary>
		/// Invokes the middleware to set cache control headers and then calls the next middleware in the pipeline.
		/// </summary>
		/// <param name="context">The HTTP context for the current request.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public async Task Invoke(HttpContext context)
        {
            context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.Response.Headers["Expires"] = "-1";
            await _next(context);
        }
    }
}
