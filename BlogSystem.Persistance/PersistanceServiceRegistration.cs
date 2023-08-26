using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSystem.Persistance
{
	public static class PersistanceServiceRegistration
	{
		public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogSystemDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IGenericAsyncRepository<>), typeof(BaseRepository<>));
			services.AddScoped<IBlogRepository, BlogRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			return services;
		}
	}
}
