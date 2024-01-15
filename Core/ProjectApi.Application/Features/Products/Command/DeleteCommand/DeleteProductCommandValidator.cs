using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Command.DeleteCommand
{
	public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
	{
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
