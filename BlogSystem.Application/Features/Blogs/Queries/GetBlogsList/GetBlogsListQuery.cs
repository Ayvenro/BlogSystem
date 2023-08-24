using MediatR;

namespace BlogSystem.Application.Features.Blogs
{
	public class GetBlogsListQuery : IRequest<List<BlogListVm>>
	{
	}
}
