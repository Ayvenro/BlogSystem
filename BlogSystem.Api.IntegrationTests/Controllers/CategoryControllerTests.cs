using BlogSystem.Api.IntegrationTests.Base;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesList;
using Shouldly;
using System.Text.Json;

namespace BlogSystem.Api.IntegrationTests.Controllers
{
	public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _customWebApplicationFactory;

		public CategoryControllerTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
		{
			_customWebApplicationFactory = customWebApplicationFactory;
		}

		[Fact]
		public async Task ReturnSuccessResult()
		{
			var client = _customWebApplicationFactory.CreateClient();
			var response = await client.GetAsync("/api/category/all");
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);
			result.ShouldBeOfType<List<CategoryListVm>>();
			result.ShouldNotBeEmpty();
		}
	}
}
