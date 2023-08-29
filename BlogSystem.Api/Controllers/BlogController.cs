using BlogSystem.Application.Features.Blogs;
using BlogSystem.Application.Features.Blogs.Commands.CreateBlog;
using BlogSystem.Application.Features.Blogs.Commands.DeleteBlog;
using BlogSystem.Application.Features.Blogs.Commands.UpdateBlog;
using BlogSystem.Application.Features.Blogs.Queries.GetBlogDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BlogController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet(Name = "GetAllBlogs")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<BlogListVm>>> GetAllBlogs()
		{
			var dtos = await _mediator.Send(new GetBlogsListQuery());
			return Ok(dtos);
		}

		[HttpGet("{id}", Name = "GetBlogById")]
		public async Task<ActionResult<BlogDetailVm>> GetBlogById(Guid id)
		{
			var dto = await _mediator.Send(new GetBlogDetailQuery() { Id = id });
			return Ok(dto);
		}

		[HttpPost(Name = "AddBlog")]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateBlogCommand createBlogCommand)
		{
			var id = await _mediator.Send(createBlogCommand);
			return Ok(id);
		}

		[HttpPut(Name = "UpdateBlog")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Update([FromBody] UpdateBlogCommand updateBlogCommand)
		{
			await _mediator.Send(updateBlogCommand);
			return NoContent();
		}

		[HttpDelete("{id}", Name = "DeleteBlog")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid id)
		{
			var deleteBlogCommand = new DeleteBlogCommand() { Id = id };
			await _mediator.Send(deleteBlogCommand);
			return NoContent();
		}
	}
}
