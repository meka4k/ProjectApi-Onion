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
	public class DetailConfiguration : IEntityTypeConfiguration<Detail>
	{
		public void Configure(EntityTypeBuilder<Detail> builder)
		{
			Faker faker = new Faker("tr");

			Detail detail1 = new()
			{
				Id = 1,
				CategoryId = 1,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CreatedDate = DateTime.Now,
				IsDeleted = true,
			};
			Detail detail2 = new()
			{
				Id = 2,
				CategoryId = 3,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};
			Detail detail3 = new()
			{
				Id = 3,
				CategoryId = 4,
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(5),
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			};

			builder.HasData(detail1, detail2, detail3);
		}
	}
}
