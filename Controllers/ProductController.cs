using csharp_api_aspnetcore_global_error_handling.AppService;
using Microsoft.AspNetCore.Mvc;

namespace csharp_api_aspnetcore_global_error_handling.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ProductAppService _appService;

		public ProductController()
		{
			_appService = new ProductAppService();
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_appService.GetProducts());
		}

		[HttpGet("GetWithException")]
		public IActionResult GetWithException()
		{
			return Ok(_appService.GetProductsWithException());
		}

		[HttpGet("GetWithCustomException")]
		public IActionResult GetWithCustomException()
		{
			return Ok(_appService.GetProductsWithCustomException());
		}
	}
}
