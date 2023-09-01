using BlogSystem.Domain.Entities;
using BlogSystem.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Api.IntegrationTests.Base
{
	public class Utilities
	{
		public static void InitializeDbForTests(BlogSystemDbContext context) 
		{
			var gameGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
			var regularGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

			context.Categories.Add(new Category
			{
				Id = gameGuid,
				Name = "Game"
			});
			context.Categories.Add(new Category
			{
				Id = regularGuid,
				Name = "Regular"
			});
			context.SaveChanges();
		}
	}
}
