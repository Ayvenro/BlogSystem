using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;

namespace BlogSystem.Persistance.Repositories
{
	public class BlogRepository : BaseRepository<Blog>, IBlogRepository
	{
		public BlogRepository(BlogSystemDbContext dbContext) : base(dbContext)
		{
		}
	}
}
