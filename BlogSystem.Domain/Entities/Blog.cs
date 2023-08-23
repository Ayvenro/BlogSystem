using BlogSystem.Domain.Common;

namespace BlogSystem.Domain.Entities
{
	public class Blog : AuditableEntity
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
