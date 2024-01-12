using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Application.Features.Products.Command.CreateProduct;
using ProjectApi.Application.Features.Products.Command.DeleteCommand;
using ProjectApi.Application.Features.Products.Command.UpdateProduct;
using ProjectApi.Application.Features.Products.Queries.GetAllProducts;
using ProjectApi.Domain.Entities;

namespace ProjectApi.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator mediator;

		public ProductsController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var response = await mediator.Send(new GetAllProductsQueryRequest());

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
		{
			await mediator.Send(request);

			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
		{
			await mediator.Send(request);

			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
		{
			await mediator.Send(request);

			return Ok();
		}
	}

	
}

