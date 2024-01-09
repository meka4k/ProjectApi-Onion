using MediatR;
using ProjectApi.Application.Interfaces.UnitOfWorks;
using ProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Command.DeleteCommand
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
		}

        public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
			product.IsDeleted = true;

			await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
			await unitOfWork.SaveAsync();
		}
	}
}
