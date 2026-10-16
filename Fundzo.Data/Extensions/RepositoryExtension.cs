using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;
using Fundzo.Core.Repositories;
using Fundzo.Data;

namespace Fundzo.Data.Extensions
{
    public static class RepositoryExtension
    {

		/// <summary>
		/// Filter data for the tenant.
		/// </summary>
		public static IQueryable<TEntity> Where<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return repository.Entities.Where(predicate);
		}

		/// <summary>
		/// Get list of data for the tenant.
		/// </summary>
		public static async Task<List<TEntity>> ToListAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Where(predicate).ToListAsync();
		}

		/// <summary>
		/// Order data for the tenant.
		/// </summary>
		public static IOrderedQueryable<TEntity> OrderBy<TEntity, TEntityKey>(this IRepository<TEntity> repository, Expression<Func<TEntity, TEntityKey>> keySelector)
			where TEntity : class
		{
			return repository.Entities.OrderBy(keySelector);
		}

		/// <summary>
		/// Get first record for the tenant.
		/// </summary>
		public static async Task<TEntity> FirstOrDefaultAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.FirstOrDefaultAsync(predicate);
		}

		/// <summary>
		/// Get first record for the tenant.
		/// </summary>
		public static async Task<TEntity> SingleOrDefaultAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.SingleOrDefaultAsync(predicate);
		}

		/// <summary>
		/// Get last record for the tenant.
		/// </summary>
		public static async Task<TEntity> LastOrDefaultAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.LastOrDefaultAsync(predicate);
		}

		/// <summary>
		/// Get first record for the tenant.
		/// </summary>
		public static async Task<TEntity> SingleAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.SingleAsync(predicate);
		}

		/// <summary>
		/// Get first record for the tenant.
		/// </summary>
		public static async Task<TEntity> FirstAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.FirstAsync(predicate);
		}

		/// <summary>
		/// Check data is exist in the tenant.
		/// </summary>
		public static async Task<bool> AnyAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.AnyAsync(predicate);
		}

		/// <summary>
		/// Count data in the tenant.
		/// </summary>
		public static async Task<int> CountAsync<TEntity>(this IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await repository.Entities.CountAsync(predicate);
		}

		/// <summary>
		/// Filter data for the tenant and include the navigation property.
		/// </summary>
		public static IIncludableQueryable<TEntity, TEntityProperty> Include<TEntity, TEntityProperty>(this IRepository<TEntity> repository, Expression<Func<TEntity, TEntityProperty>> path)
			where TEntity : class
		{
			return repository.Entities.Include(path);
		}

		public static IQueryable<TEntityResult> Select<TEntity, TEntityResult>(this IRepository<TEntity> repository, Expression<Func<TEntity, TEntityResult>> selector)
			where TEntity : class
		{
			return repository.Entities.Select(selector);
		}

		public static async Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
			where TEntity : class
		{
			return await query.Where(predicate).ToListAsync();
		}

		public static async Task<TEntity> FirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
		{
			return await query.Where(predicate).FirstOrDefaultAsync();
		}

	}
}
