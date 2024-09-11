using Cintruct.MvcUi.ApiServices.Interfaces;
using Cintruct.MvcUi.Models.Responses;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Cintruct.MvcUi.Extensions;

namespace Cintruct.MvcUi.Controllers
{
	public class BaseController : Controller
	{
		protected IConfiguration _configuration;
		protected IHttpApiService _httpApiService;
		protected TokenResponse _tokenResponse;
		public BaseController(IConfiguration configuration, IHttpApiService httpApiService)
		{
			_configuration = configuration;
			_httpApiService = httpApiService;
		}

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
