﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Interfaces.Automapper
{
	public interface IMapper
	{
		// Mapper.Map<BrandDto,Brand>(brand)
		TDestination Map<TDestination,TSource>(TSource source,string? ignore=null);
		IList<TDestination> Map<TDestination,TSource>(IList<TSource> source,string? ignore=null);

		TDestination Map<TDestination>(object source, string? ignore = null);
		IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);
	}
}
