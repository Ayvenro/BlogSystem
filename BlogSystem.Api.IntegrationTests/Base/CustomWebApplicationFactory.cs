using BlogSystem.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlogSystem.Api.IntegrationTests.Base
{
	public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddDbContext<BlogSystemDbContext>(options =>
				{
					options.UseInMemoryDatabase("BlogSystemDbContextInMemoryTest");
				});
				var sp = services.BuildServiceProvider();
				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var context = scopedServices.GetRequiredService<BlogSystemDbContext>();
					var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();
					context.Database.EnsureDeleted();
					context.Database.EnsureCreated();
					try
					{
						Utilities.InitializeDbForTests(context);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, $"An error occured seeding the database with test messages. Error: {ex.Message}");
					}
				}
			});
		}
	}
}
