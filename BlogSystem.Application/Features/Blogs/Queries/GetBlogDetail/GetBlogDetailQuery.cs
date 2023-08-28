using MediatR;

namespace BlogSystem.Application.Features.Blogs.Queries.GetBlogDetail
{
	public class GetBlogDetailQuery : IRequest<BlogDetailVm>
	{
        public Guid Id { get; set; }
    }
}
