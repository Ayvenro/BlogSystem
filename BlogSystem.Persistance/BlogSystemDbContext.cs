using BlogSystem.Domain.Common;
using BlogSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Persistance
{
	public class BlogSystemDbContext : DbContext
	{
		public BlogSystemDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.Entity.LastModifiedDate = DateTime.Now;
						break;
					case EntityState.Added:
						entry.Entity.CreatedDate = DateTime.Now;
						break;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogSystemDbContext).Assembly);

			var gameGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
			var regularGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

			modelBuilder.Entity<Category>().HasData(new Category
			{
				Id = gameGuid,
				Name = "Game"
			});;
			modelBuilder.Entity<Category>().HasData(new Category 
			{ 
				Id = regularGuid,
				Name = "Regular" 
			});

			modelBuilder.Entity<Blog>().HasData(new Blog
			{
				Id = Guid.NewGuid(),
				Title = "Test game title",
				Content = "Test game content",
				CategoryId = gameGuid,
			});
			modelBuilder.Entity<Blog>().HasData(new Blog
			{
				Id = Guid.NewGuid(),
				Title = "Test new game title",
				Content = "Test new game content",
				CategoryId = gameGuid,
			});
			modelBuilder.Entity<Blog>().HasData(new Blog
			{
				Id = Guid.NewGuid(),
				Title = "Test regular title",
				Content = "Test regular content",
				CategoryId = regularGuid,
			});
		}
	}
}
