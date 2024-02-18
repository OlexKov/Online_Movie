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
		Task<IEnumerable<TEntity>> GetAsync(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string includeProperties = "");
		

		TEntity? GetByID(object id);
		Task<TEntity?> GetByIDAsync(object id);
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
