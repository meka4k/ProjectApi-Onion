﻿using MediatR;
using ProjectApi.Application.Interfaces.Automapper;
using ProjectApi.Application.Interfaces.UnitOfWorks;
using ProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Command.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest,Unit>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public UpdateProductCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

			var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

			var productCategories = await unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);

			await unitOfWork.GetWriteRepository<ProductCategory>().HardRangeDelete(productCategories);

			foreach (var categoryId in request.CategoryIds)
				await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory
				{
					CategoryId = categoryId,
					ProductId = product.Id
				});

			await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
			await unitOfWork.SaveAsync();

			return Unit.Value;
		}
	}
}
