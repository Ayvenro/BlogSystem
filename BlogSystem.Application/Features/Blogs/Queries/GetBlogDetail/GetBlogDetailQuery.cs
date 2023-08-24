using MediatR;

namespace BlogSystem.Application.Features.Blogs
{
	public class GetBlogDetailQuery : IRequest<BlogDetailVm>
	{
        public Guid Id { get; set; }
    }
}
