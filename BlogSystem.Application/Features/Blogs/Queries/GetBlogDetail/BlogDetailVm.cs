using BlogSystem.Domain.Entities;

namespace BlogSystem.Application.Features.Blogs.Queries.GetBlogDetail
{
    public class BlogDetailVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = default!;
    }
}