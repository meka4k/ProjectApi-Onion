using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Command.DeleteCommand
{
	public class DeleteProductCommandRequest:IRequest
	{
        public int Id { get; set; }
    }
}
