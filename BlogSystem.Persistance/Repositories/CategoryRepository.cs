using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Persistance.Repositories
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(BlogSystemDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Category>> GetCategoriesWithBlogs()
		{
			var allCategories = await _dbContext.Categories.Include(x => x.Blogs).ToListAsync();
			return allCategories;
		}
	}
}
