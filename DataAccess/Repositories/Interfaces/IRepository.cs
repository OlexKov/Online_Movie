using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string includeProperties = "");
		Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
																	Expression<Func<TEntity, bool>> predicate = null,
																	Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
																	Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
																	bool disableTracking = true);



		TEntity? GetByID(object id);
		Task<TEntity?> GetByIDAsync(object id);
		Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
										  Expression<Func<TEntity, bool>> predicate = null,
										  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
										  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
										  bool disableTracking = true);
		void Insert(TEntity entity);
		Task InsertAsync(TEntity entity);
		void Delete(object id);
		Task DeleteAsync(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
		Task SaveAsync();
		void Save();
	}
}
