using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using DataAccess.Data;
using BusinessLogic.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;



namespace DataAccess.Repositories
{
	internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		internal OnlineMovieDBContext context;
		internal DbSet<TEntity> dbSet;

		public Repository(OnlineMovieDBContext context)
		{
			this.context = context;
			this.dbSet = context.Set<TEntity>();
		}

		public virtual async Task<TEntity?> GetByIDAsync(object id) =>  await dbSet.FindAsync(id);

		public async Task<TResult?> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector ,
										  Expression<Func<TEntity, bool>>? predicate = null,
										  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
										  bool disableTracking = false)
		{
			IQueryable<TEntity> query = dbSet;
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			
			return await query.Select(selector).FirstOrDefaultAsync();
		}


		
		
		public async virtual Task InsertAsync(TEntity entity) => await dbSet.AddAsync(entity);
		
		public virtual void Delete(object id)
		{
			TEntity? entityToDelete = dbSet.Find(id);
			if(entityToDelete != null)
			   Delete(entityToDelete);
		}

		public async virtual Task DeleteAsync(object id)
		{
			TEntity? entityToDelete = await dbSet.FindAsync(id);
			if (entityToDelete != null)
				 Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
			{
				dbSet.Attach(entityToDelete);
			}
			dbSet.Remove(entityToDelete);
		}
		
		public virtual void Update(TEntity entityToUpdate)
		{
			dbSet.Attach(entityToUpdate);
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		
		
		public async Task SaveAsync() => await context.SaveChangesAsync();

		public async Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification)
		{
			return await ApplySpecification(specification).ToListAsync();
		}

		public async Task<TEntity?> GetItemBySpec(ISpecification<TEntity> specification)
		{
			return await ApplySpecification(specification).FirstOrDefaultAsync();
		}

		private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
		{
			var evaluator = new SpecificationEvaluator();
			return evaluator.GetQuery(dbSet, specification);
		}
	}
}
