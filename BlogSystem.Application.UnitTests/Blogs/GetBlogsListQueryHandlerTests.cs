using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Application.Features.Blogs;
using BlogSystem.Application.Profiles;
using BlogSystem.Application.UnitTests.Mock;
using BlogSystem.Domain.Entities;
using Moq;
using Shouldly;

namespace BlogSystem.Application.UnitTests.Blogs
{
    public class GetBlogsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGenericAsyncRepository<Blog>> _mockBlogRepository;

        public GetBlogsListQueryHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(options =>
            {
                options.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
            _mockBlogRepository = RepositoryMocks.GetBlogRepository();
        }

        [Fact]
        public async Task GetBlogsListTest()
        {
            var handler = new GetBlogsListQueryHandler(_mapper, _mockBlogRepository.Object);
            var result = await handler.Handle(new GetBlogsListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<BlogListVm>>();
            result.Count.ShouldBe(4);
        }
    }
}
