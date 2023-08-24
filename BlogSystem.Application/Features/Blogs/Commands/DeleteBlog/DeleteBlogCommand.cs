using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.DeleteBlog
{
	public class DeleteBlogCommand : IRequest
	{
        public Guid Id { get; set; }
    }
}
