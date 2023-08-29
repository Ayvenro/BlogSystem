using BlogSystem.Application;
using BlogSystem.Infrastructure;
using BlogSystem.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BlogSystem.Api
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddApplicationServices();
			AddSwagger(builder.Services);
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
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog System API");
				});
			}
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors("Open");
			app.MapControllers();
			return app;
		}

		private static void AddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Blog system API"
				});
			});
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
