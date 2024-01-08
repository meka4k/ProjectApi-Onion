using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Application.Interfaces.UnitOfWorks;
using ProjectApi.Domain.Entities;

namespace ProjectApi.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductsController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
		}
	}
}
