using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Application.Features.Categories.Commands.CreateCategory;
using BlogSystem.Application.Profiles;
using BlogSystem.Application.UnitTests.Mock;
using BlogSystem.Domain.Entities;
using Moq;
using Shouldly;

namespace BlogSystem.Application.UnitTests.Categories.Commands
{
	public class CreateCategoryTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IGenericAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationMapper = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
            });
            _mapper = configurationMapper.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedCategoriesToRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);
            await handler.Handle(new CreateCategoryCommand() { Name = "Test1"}, CancellationToken.None);
            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();
            allCategories.Count.ShouldBe(3);
        }
    }
}
