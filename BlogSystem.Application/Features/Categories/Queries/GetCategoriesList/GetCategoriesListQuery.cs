using MediatR;

namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
	{
	}
}
