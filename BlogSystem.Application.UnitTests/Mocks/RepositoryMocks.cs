using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using Moq;

namespace BlogSystem.Application.UnitTests.Mocks
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
	}
}
