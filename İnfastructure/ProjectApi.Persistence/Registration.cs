using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectApi.Application.Interfaces.Repositories;
using ProjectApi.Application.Interfaces.UnitOfWorks;
using ProjectApi.Persistence.Context;
using ProjectApi.Persistence.Repositories;
using ProjectApi.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Persistence
{
	public static class Registration
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

			services.AddScoped<IUnitOfWork,UnitOfWork>();
		}
	}
}
