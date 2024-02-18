using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DataAccess.Repositories.Interfaces;

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

		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public async virtual Task<IEnumerable<TEntity>> GetAsync(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}

		public virtual TEntity? GetByID(object id) => dbSet.Find(id);
		
		public async virtual Task<TEntity?> GetByIDAsync(object id) => await dbSet.FindAsync(id);
		
		public virtual void Insert(TEntity entity) => dbSet.Add(entity);
		
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

		public void Save() => context.SaveChanges();
		
		public async Task SaveAsync() => await context.SaveChangesAsync();
	}
}
