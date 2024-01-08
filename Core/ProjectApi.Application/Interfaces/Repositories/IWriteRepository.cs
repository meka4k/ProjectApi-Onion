﻿using ProjectApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> where T : class,IEntityBase, new()
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		Task<T> UpdateAsync(T entity);
		Task HardDelete(T entity);	
	}
}
