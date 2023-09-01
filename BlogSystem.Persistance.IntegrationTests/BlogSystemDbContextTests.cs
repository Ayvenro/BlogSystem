using BlogSystem.Application.Contracts;
using BlogSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace BlogSystem.Persistance.IntegrationTests
{
	public class BlogSystemDbContextTests
	{
		private readonly BlogSystemDbContext _blogSystemDbContext;
		private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
		private readonly string _loggedInUserId;
		private readonly DateTime _createdDate;

		public BlogSystemDbContextTests()
		{
			var dbContextOptions = new DbContextOptionsBuilder<BlogSystemDbContext>().UseInMemoryDatabase
				(Guid.NewGuid().ToString()).Options;
			_loggedInUserId = "00000000-0000-0000-0000-000000000000";
			_createdDate = DateTime.Now;
			_loggedInUserServiceMock = new Mock<ILoggedInUserService>();
			_loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);
			_blogSystemDbContext = new BlogSystemDbContext (dbContextOptions, _loggedInUserServiceMock.Object);
		}

		[Fact]
		public async void Save_SetCreatedByProperty()
		{
			var blog = new Blog { Id = Guid.NewGuid(), Title = "Test blog" };
			_blogSystemDbContext.Blogs.Add(blog);
			await _blogSystemDbContext.SaveChangesAsync();
			blog.CreatedBy.ShouldBe(_loggedInUserId);
		}

		[Fact]
		public async void Save_SetCreatedDateProperty()
		{
			var blog = new Blog { Id = Guid.NewGuid(), Title = "Test blog" };
			_blogSystemDbContext.Blogs.Add (blog);
			await _blogSystemDbContext.SaveChangesAsync();
			blog.CreatedDate.ShouldBe(_createdDate, new TimeSpan(0, 0, 1));
		}
	}
}