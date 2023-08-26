using BlogSystem.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Persistance.Repositories
{
	public class BaseRepository<T> : IGenericAsyncRepository<T> where T : class
	{
		protected readonly BlogSystemDbContext _dbContext;

		public BaseRepository(BlogSystemDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
