using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Persistence.Configurations
{
	public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
	{
		public void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			builder.HasKey(x=> new {x.ProductId , x.CategoryId });

			builder.HasOne(p=>p.Product).WithMany(cp=>cp.ProductCategories).HasForeignKey(x=>x.ProductId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);
			builder.HasOne(c=>c.Category).WithMany(cp=>cp.ProductCategories).HasForeignKey(x=>x.CategoryId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);
		}
	}
}
