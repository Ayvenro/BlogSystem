using BlogSystem.Domain.Common;

namespace BlogSystem.Domain.Entities
{
	public class Category : AuditableEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Blog> Blogs { get; set; }
    }
}
