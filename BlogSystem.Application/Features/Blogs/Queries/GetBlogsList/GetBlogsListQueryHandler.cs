using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using MediatR;
using BlogSystem.Domain.Entities;

namespace BlogSystem.Application.Features.Blogs
{
	public class GetBlogsListQueryHandler : IRequestHandler<GetBlogsListQuery, List<BlogListVm>>
	{
		private readonly IMapper _mapper;
		private readonly IGenericAsyncRepository<Blog> _blogRepository;

		public GetBlogsListQueryHandler(IMapper mapper, IGenericAsyncRepository<Blog> blogRepository)
        {
			_mapper = mapper;
			_blogRepository = blogRepository;
        }

        public async Task<List<BlogListVm>> Handle(GetBlogsListQuery request, CancellationToken cancellationToken)
		{
			var allBlogs = (await _blogRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
			return _mapper.Map<List<BlogListVm>>(allBlogs);
		}
	}
}
