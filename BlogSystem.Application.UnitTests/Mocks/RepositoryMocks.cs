using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using Moq;
using System.Reflection.Emit;

namespace BlogSystem.Application.UnitTests.Mock
{
	public class RepositoryMocks
	{
		public static Mock<IGenericAsyncRepository<Category>> GetCategoryRepository()
		{
			var gameGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
			var regularGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

			var categories = new List<Category>
			{
				new Category
				{
					Id = gameGuid,
					Name = "Game"
				},
				new Category
				{
					Id = regularGuid,
					Name = "Regular"
				}
			};

			var mockCategoryRepository = new Mock<IGenericAsyncRepository<Category>>();
			mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);
			mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
			{
				categories.Add(category);
				return category;
			});
			return mockCategoryRepository;
		}

		public static Mock<IGenericAsyncRepository<Blog>> GetBlogRepository()
		{
			var gameGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
			var regularGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
			var blogs = new List<Blog>
			{
				new Blog
				{
					Id = Guid.NewGuid(),
					Title = "Test game title",
					Content = "Test game content",
					CategoryId = gameGuid
				},
				new Blog
				{
					Id = Guid.NewGuid(),
					Title = "Test new game title",
					Content = "Test new game content",
					CategoryId = gameGuid
				},
				new Blog
				{
					Id = Guid.NewGuid(),
					Title = "Test regular title",
					Content = "Test regular content",
					CategoryId = regularGuid
				},
				new Blog
				{
					Id = Guid.NewGuid(),
					Title = "Test new regular title",
					Content = "Test new regular content",
					CategoryId = regularGuid
				}
			};
			var mockBlogRepository = new Mock<IGenericAsyncRepository<Blog>>();
			mockBlogRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(blogs);
			mockBlogRepository.Setup(repo => repo.AddAsync(It.IsAny<Blog>())).ReturnsAsync((Blog blog) =>
			{
				blogs.Add(blog);
				return blog;
			});
			return mockBlogRepository;
		}
	}
}
