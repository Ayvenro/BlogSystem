using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Blogs.Queries.GetBlogDetail
{
	public class GetBlogDetailHandlerQuery : IRequestHandler<GetBlogDetailQuery, BlogDetailVm>
	{
		private readonly IMapper _mapper;
		private readonly IGenericAsyncRepository<Blog> _blogRepository;
		private readonly IGenericAsyncRepository<Category> _categoryRepository;

		public GetBlogDetailHandlerQuery(IMapper mapper, IGenericAsyncRepository<Blog> blogRepository, IGenericAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_blogRepository = blogRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<BlogDetailVm> Handle(GetBlogDetailQuery request, CancellationToken cancellationToken)
		{
			var @blog = await _blogRepository.GetByIdAsync(request.Id);
			var blogDetailDto = _mapper.Map<BlogDetailVm>(@blog);
			var category = await _categoryRepository.GetByIdAsync(@blog.CategoryId);
			blogDetailDto.Category = _mapper.Map<CategoryDto>(category);
			return blogDetailDto;
		}
	}
}
