﻿using Microsoft.EntityFrameworkCore.Query;
using ProjectApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Application.Interfaces.Repositories
{
	public interface IReadRepository<T> where T : class, IEntityBase, new()
	{
		Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			bool enableTracking = false
			);

		Task<IList<T>> GetAllPagingAsync(Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			int currentPage = 1, int sizePage = 3,
			bool enableTracking = false
			);

		Task<T> GetAsync(Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool enableTracking = false
			);

		IQueryable<T> Find(Expression<Func<T, bool>> predicate);

		Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);



	}
}