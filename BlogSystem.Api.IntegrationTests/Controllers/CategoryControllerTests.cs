using BlogSystem.Api.IntegrationTests.Base;
using BlogSystem.Application.Features.Categories.Commands.CreateCategory;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesList;
using BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs;
using Shouldly;
using System.Text.Json;
using System.Text;
using System.Net;

namespace BlogSystem.Api.IntegrationTests.Controllers
{
	public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _customWebApplicationFactory;
		private readonly HttpClient _httpClient;

		public CategoryControllerTests(CustomWebApplicationFactory<Program> customWebApplicationFactory)
		{
			_customWebApplicationFactory = customWebApplicationFactory;
			_httpClient = _customWebApplicationFactory.CreateClient();
		}

		[Fact]
		public async Task GetAllCategories_ReturnSuccessResult()
		{
			var response = await _httpClient.GetAsync("/api/category/all");
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<List<CategoryListVm>>(responseString);
			result.ShouldBeOfType<List<CategoryListVm>>();
			result.ShouldNotBeEmpty();
		}

		[Fact]
		public async Task GetAllCategoriesWithBlogs_ReturnSuccessResult()
		{
			var response = await _httpClient.GetAsync("/api/category/allwithblogs");
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<List<CategoryBlogListVm>>(responseString);
			result.ShouldBeOfType<List<CategoryBlogListVm>>();
			result.ShouldNotBeEmpty();
		}

		[Fact]
		public async Task CreateCategory_ReturnSuccessResult()
		{
			var createCategoryCommand = new CreateCategoryCommand
			{
				Name = "New category"
			};
			var content = new StringContent(JsonSerializer.Serialize(createCategoryCommand), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("/api/category", content);
			response.StatusCode.ShouldBe(HttpStatusCode.OK);
			var responseString = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<CreateCategoryCommandResponse>(responseString);
			result.ShouldNotBeNull();
		}
	}
}
