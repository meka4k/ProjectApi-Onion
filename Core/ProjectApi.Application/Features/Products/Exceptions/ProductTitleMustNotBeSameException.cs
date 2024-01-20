using ProjectApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Features.Products.Exceptions
{
	public class ProductTitleMustNotBeSameException:BaseExceptions
	{
        public ProductTitleMustNotBeSameException():base("Ürün başlığı zaten var!")
		{

		}

	}
}
