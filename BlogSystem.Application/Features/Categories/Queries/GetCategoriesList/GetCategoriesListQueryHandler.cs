using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
	{
		private readonly IMapper _mapper;
		private readonly IGenericAsyncRepository<Category> _categoryRepository;

		public GetCategoriesListQueryHandler(IMapper mapper, IGenericAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
		{
			var allCategories = (await _categoryRepository.GetAllAsync()).OrderBy(x => x.Name);
			return _mapper.Map<List<CategoryListVm>>(allCategories);
		}
	}
}
