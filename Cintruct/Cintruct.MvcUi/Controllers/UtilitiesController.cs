using Cintruct.MvcUi.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cintruct.MvcUi.Controllers
{
    public class UtilitiesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpApiService _httpApiService;
        public UtilitiesController(IConfiguration configuration, IHttpApiService httpApiService)
        {
            _configuration = configuration;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public IActionResult UnAuthorizePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NotFoundPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
