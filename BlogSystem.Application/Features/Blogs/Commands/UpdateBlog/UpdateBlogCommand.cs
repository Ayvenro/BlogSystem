using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.UpdateBlog
{
	public class UpdateBlogCommand : IRequest
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
	}
}
