using BlogSystem.Domain.Entities;

namespace BlogSystem.Application.Contracts.Persistence
{
	public interface ICategoryRepository : IGenericAsyncRepository<Category>
	{
		Task<List<Category>> GetCategoriesWithBlogs(bool includePassedBlogs);
	}
}
