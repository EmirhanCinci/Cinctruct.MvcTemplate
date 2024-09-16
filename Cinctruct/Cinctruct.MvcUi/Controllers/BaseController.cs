using Cintruct.MvcUi.ApiServices.Interfaces;
using Cintruct.MvcUi.Models.Responses;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Cintruct.MvcUi.Extensions;

namespace Cintruct.MvcUi.Controllers
{
	/// <summary>
	/// A base controller class providing common functionality for all controllers in the application.
	/// </summary>
	public class BaseController : Controller
	{
		/// <summary>
		/// The configuration settings for the application.
		/// </summary>
		protected IConfiguration _configuration;

		/// <summary>
		/// The HTTP API service used for making API calls.
		/// </summary>
		protected IHttpApiService _httpApiService;

		/// <summary>
		/// The token response used for authentication and authorization.
		/// </summary>
		protected TokenResponse _tokenResponse;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseController"/> class with the specified configuration and HTTP API service.
		/// </summary>
		/// <param name="configuration">The configuration settings for the application.</param>
		/// <param name="httpApiService">The HTTP API service used for making API calls.</param>
		public BaseController(IConfiguration configuration, IHttpApiService httpApiService)
		{
			_configuration = configuration;
			_httpApiService = httpApiService;
		}

		/// <summary>
		/// Called before the action method is executed to check if the user is authenticated.
		/// </summary>
		/// <param name="context">The context for the action execution.</param>
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			_tokenResponse = context.HttpContext.Session.GetObject<TokenResponse>("ActiveToken");
			if (_tokenResponse == null)
			{
				HttpContext.Session.Clear();
				context.Result = new RedirectResult("~/Authentication/Login");
			}
		}
	}
}
