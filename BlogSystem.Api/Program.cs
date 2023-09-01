using BlogSystem.Api;

public class Program
{
	private static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder
			.ConfigureServices()
			.ConfigurePipeline();

		await app.ResetDataBaseAsync();
		app.Run();
	}
}