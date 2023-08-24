using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using MediatR;

namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs
{
	public class GetCategoriesListWithBlogsQueryHandler : IRequestHandler<GetCategoriesListWithBlogsQuery, List<CategoryBlogListVm>>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;

		public GetCategoriesListWithBlogsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryBlogListVm>> Handle(GetCategoriesListWithBlogsQuery request, CancellationToken cancellationToken)
		{
			var categoriesList = await _categoryRepository.GetCategoriesWithBlogs(request.IncludeHistory);
			return _mapper.Map<List<CategoryBlogListVm>>(categoriesList);
		}
	}
}
