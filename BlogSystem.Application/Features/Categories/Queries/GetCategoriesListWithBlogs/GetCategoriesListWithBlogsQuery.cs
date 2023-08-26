using MediatR;

namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs
{
	public class GetCategoriesListWithBlogsQuery : IRequest<List<CategoryBlogListVm>>
	{
    }
}
