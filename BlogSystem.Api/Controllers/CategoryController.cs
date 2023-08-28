using BlogSystem.Application.Features.Categories.Commands.CreateCategory;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesList;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoryController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("all", Name = "GetAllCategories")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
		{
			var dtos = await _mediator.Send(new GetCategoriesListQuery());
			return Ok(dtos);
		}

		[HttpGet("allwithblogs", Name = "GetAllCategoriesWithBlogs")]
		[ProducesDefaultResponseType]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<CategoryBlogListVm>>> GetAllCategoriesWithBlogs()
		{
			var dtos = await _mediator.Send(new GetCategoriesListWithBlogsQuery());
			return Ok(dtos);
		}

		[HttpPost(Name = "AddCategory")]
		public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
		{
			var response = await _mediator.Send(createCategoryCommand);
			return Ok(response);
		}
	}
}
