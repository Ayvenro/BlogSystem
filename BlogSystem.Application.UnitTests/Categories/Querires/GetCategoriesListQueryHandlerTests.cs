using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesList;
using BlogSystem.Application.Profiles;
using BlogSystem.Application.UnitTests.Mock;
using BlogSystem.Domain.Entities;
using Moq;
using Shouldly;

namespace BlogSystem.Application.UnitTests.Categories.Querires
{
	public class GetCategoriesListQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IGenericAsyncRepository<Category>> _mockCategoryRepository;

		public GetCategoriesListQueryHandlerTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var mapperConfiguration = new MapperConfiguration(options =>
			{
				options.AddProfile<MappingProfile>();	
			});
			_mapper = mapperConfiguration.CreateMapper();
		}

		[Fact]
		public async Task GetCategoriesListTest()
		{
			var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);
			var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
			result.ShouldBeOfType<List<CategoryListVm>>();
			result.Count.ShouldBe(2);
		}
	}
}
