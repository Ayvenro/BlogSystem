using BlogSystem.Application;
using BlogSystem.Infrastructure;
using BlogSystem.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Api
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistanceServices(builder.Configuration);
			builder.Services.AddControllers();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			});
			return builder.Build();
		}

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors("Open");
			app.MapControllers();
			return app;
		}

		public static async Task ResetDataBaseAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			try
			{
				var context = scope.ServiceProvider.GetService<BlogSystemDbContext>();
				if (context != null)
				{
					await context.Database.EnsureDeletedAsync();
					await context.Database.MigrateAsync();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}
