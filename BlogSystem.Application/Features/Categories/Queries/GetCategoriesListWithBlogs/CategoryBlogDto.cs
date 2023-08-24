namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs
{
	public class CategoryBlogDto
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
		public Guid CategoryId { get; set; }
	}
}
