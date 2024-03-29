﻿using BlogSystem.Domain.Entities;

namespace BlogSystem.Application.Contracts.Persistence
{
	public interface IBlogRepository : IGenericAsyncRepository<Blog>
	{

	}
}
