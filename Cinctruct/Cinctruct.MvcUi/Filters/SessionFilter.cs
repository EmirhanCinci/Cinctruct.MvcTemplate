using Cintruct.MvcUi.ApiServices.Interfaces;
using Cintruct.MvcUi.Models.Responses;
using Cintruct.MvcUi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Cintruct.MvcUi.Extensions;

namespace Cintruct.MvcUi.Filters
{
	/// <summary>
	/// An action filter that handles session management and token refreshing for authenticated requests.
	/// </summary>
	public class SessionFilter : ActionFilterAttribute
	{
		private readonly IConfiguration _configuration;
		private readonly IHttpApiService _httpApiService;

		/// <summary>
		/// Initializes a new instance of the <see cref="SessionFilter"/> class with the specified configuration and HTTP API service.
		/// </summary>
		/// <param name="configuration">The configuration settings for the application.</param>
		/// <param name="httpApiService">The HTTP API service used for making API calls.</param>
		public SessionFilter(IConfiguration configuration, IHttpApiService httpApiService)
		{
			_configuration = configuration;
			_httpApiService = httpApiService;
		}

		/// <summary>
		/// Called before the action method is executed to check and refresh the user's session token if needed.
		/// </summary>
		/// <param name="context">The context for the action execution.</param>
		/// <param name="next">The delegate representing the next action in the pipeline.</param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var activeToken = context.HttpContext.Session.GetObject<TokenResponse>("ActiveToken");
			if (activeToken == null || DateTime.Now >= activeToken.RefreshTokenExpiration)
			{
				ClearSessionAndRedirect(context);
				return;
			}
			if (DateTime.Now >= activeToken.AccessTokenExpiration)
			{
				var refreshedToken = await RefreshToken(activeToken.RefreshToken);
				if (refreshedToken == null)
				{
					ClearSessionAndRedirect(context);
					return;
				}
				activeToken = refreshedToken;
			}
			context.HttpContext.Session.SetObject("ActiveToken", activeToken);
			await next();
		}

		/// <summary>
		/// Refreshes the user's access token using the provided refresh token.
		/// </summary>
		/// <param name="refreshToken">The refresh token used to request a new access token.</param>
		/// <returns>The refreshed token response if successful; otherwise, null.</returns>
		private async Task<TokenResponse?> RefreshToken(string refreshToken)
		{
			var postDto = new { token = refreshToken };
			var response = await _httpApiService.PostDataAsync<ResponseBody<TokenResponse>>("BaseAddress", "/Authentication/CreateTokenByRefreshToken", JsonSerializer.Serialize(postDto));
			return response.StatusCode == 201 ? response.Data : null;
		}

		/// <summary>
		/// Clears the session and redirects the user to the login page.
		/// </summary>
		/// <param name="context">The context for the action execution.</param>
		private void ClearSessionAndRedirect(ActionExecutingContext context)
		{
			context.HttpContext.Session.Clear();
			context.Result = new RedirectResult("~/Authentication/Login");
		}
	}
}
