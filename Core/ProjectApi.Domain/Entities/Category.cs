using ProjectApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Domain.Entities
{
	public class Category : EntityBase
	{
		public Category()
		{

		}
		public Category(int parentId, string name, int pariorty)
		{
			ParentId = parentId;
			Name = name;
			Pariorty = pariorty;
		}


		public int ParentId { get; set; }
		public string Name { get; set; }
		public int Pariorty { get; set; }
		public ICollection<Detail> Details { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
