using Bogus;
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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			Faker faker = new Faker("tr");

			Product product1 = new()
			{
				Id = 1,
				BrandId = 1,
				Title = faker.Commerce.ProductName(),
				Description = faker.Commerce.ProductDescription(),
				Discount = faker.Random.Decimal(0, 10),
				Price = faker.Finance.Amount(10, 100),
				IsDeleted = false,
				CreatedDate = DateTime.Now
			};
			Product product2 = new()
			{
				Id = 2,
				BrandId = 3,
				Title = faker.Commerce.ProductName(),
				Description = faker.Commerce.ProductDescription(),
				Discount = faker.Random.Decimal(0, 10),
				Price = faker.Finance.Amount(10, 100),
				IsDeleted = false,
				CreatedDate = DateTime.Now
			};

			builder.HasData(product1,product2);
		}
	}
}
