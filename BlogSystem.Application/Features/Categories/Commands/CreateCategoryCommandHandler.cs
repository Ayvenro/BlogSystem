﻿using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var createCategoryCommandResponse = new CreateCategoryCommandResponse();
			var validator = new CreateCategoryCommandValidator();
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Count > 0) 
			{
				createCategoryCommandResponse.Success = false;
				createCategoryCommandResponse.Errors = new List<string>();
				foreach (var error in validationResult.Errors)
				{
					createCategoryCommandResponse.Errors.Add(error.ErrorMessage);
				}
			}
			if (createCategoryCommandResponse.Success)
			{
				var category = new Category() { Name = request.Name };
				category = await _categoryRepository.AddAsync(category);
				createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
			}
			return createCategoryCommandResponse;
		}
	}
}
