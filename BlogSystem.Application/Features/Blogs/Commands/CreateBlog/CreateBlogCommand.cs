using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Application.Features.Blogs.Commands.CreateBlog
{
	public class CreateBlogCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
		public override string ToString()
		{
			return $"Blog name: {Title}; Content: {Content}";
		}
	}
}
