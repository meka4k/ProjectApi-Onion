using Microsoft.Extensions.DependencyInjection;
using ProjectApi.Application.Interfaces.Automapper;
using ProjectApi.Mapper.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Mapper
{
	public static class Registration
	{
		public static void AddCustomMapper(this IServiceCollection services)
		{
			services.AddSingleton<IMapper,Automapper.Mapper>();
		}
	}
}
