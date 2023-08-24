namespace BlogSystem.Application.Features.Categories.Queries.GetCategoriesListWithBlogs
{
	public class CategoryBlogListVm
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryBlogDto>? Blogs { get; set; }
    }
}
