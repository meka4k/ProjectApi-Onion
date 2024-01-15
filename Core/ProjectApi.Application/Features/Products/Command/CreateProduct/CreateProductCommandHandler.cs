﻿using MediatR;
using ProjectApi.Application.Interfaces.UnitOfWorks;
using ProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Command.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
	{
		private readonly IUnitOfWork unitOfWork;

		public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
			await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

			if (await unitOfWork.SaveAsync() > 0)
			{

			
				foreach (var categoryId in request.CategoryIds)
					await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
					{
						ProductId = product.Id,
						CategoryId = categoryId
					});
				await unitOfWork.SaveAsync();

				
			}
			return Unit.Value;
		}
	}
}
