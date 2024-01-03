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
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category category = new()
			{
				Id = 1,
				Name = "Elektronik",
				Pariorty = 1,
				ParentId = 0,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};
			Category category2 = new()
			{
				Id = 2,
				Name = "Moda",
				Pariorty = 2,
				ParentId = 0,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};

			Category parent1 = new()
			{
				Id = 3,
				Name = "Bilgisayar",
				Pariorty = 1,
				ParentId = 1,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};
			Category parent2 = new()
			{
				Id = 4,
				Name = "Kadın",
				Pariorty = 1,
				ParentId = 2,
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};

			builder.HasData(category, category2,parent1,parent2);
		}
	}
}
