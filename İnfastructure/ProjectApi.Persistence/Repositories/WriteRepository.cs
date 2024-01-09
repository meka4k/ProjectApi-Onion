using Microsoft.EntityFrameworkCore;
using ProjectApi.Application.Interfaces.Repositories;
using ProjectApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApi.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
	{
		private readonly DbContext dbContext;

		public WriteRepository(DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		private DbSet<T> Table { get => dbContext.Set<T>(); }

		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			await Table.AddRangeAsync(entities);
		}

		public async Task HardDelete(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
		}
		public async Task HardRangeDelete(IList<T> entity)
		{
			await Task.Run(() => Table.RemoveRange(entity));
		}

		public async Task<T> UpdateAsync(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;
		}
	}
}
