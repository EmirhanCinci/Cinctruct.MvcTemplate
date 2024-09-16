using Cintruct.MvcUi.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cintruct.MvcUi.Controllers
{
	/// <summary>
	/// A controller class for handling utility pages such as authorization errors, not found errors, and general errors.
	/// </summary>
	public class UtilitiesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpApiService _httpApiService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UtilitiesController"/> class with the specified configuration and HTTP API service.
		/// </summary>
		/// <param name="configuration">The configuration settings for the application.</param>
		/// <param name="httpApiService">The HTTP API service used for making API calls.</param>
		public UtilitiesController(IConfiguration configuration, IHttpApiService httpApiService)
        {
            _configuration = configuration;
            _httpApiService = httpApiService;
        }

		/// <summary>
		/// Displays the unauthorized access page.
		/// </summary>
		/// <returns>The view representing the unauthorized access page.</returns>
		[HttpGet]
        public IActionResult UnAuthorizePage()
        {       
            return View();
        }

		/// <summary>
		/// Displays the not found page.
		/// </summary>
		/// <returns>The view representing the not found page.</returns>
		[HttpGet]
        public IActionResult NotFoundPage()
        {
            return View();
        }

		/// <summary>
		/// Displays the error page.
		/// </summary>
		/// <returns>The view representing the error page.</returns>
		[HttpGet]
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
