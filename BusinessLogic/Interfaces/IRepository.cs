using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore.Query;
namespace BusinessLogic.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByIDAsync(object id);
		Task InsertAsync(TEntity entity);
		void Delete(object id);
		Task DeleteAsync(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
		Task SaveAsync();
		Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification);
		Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification);
	}
}
