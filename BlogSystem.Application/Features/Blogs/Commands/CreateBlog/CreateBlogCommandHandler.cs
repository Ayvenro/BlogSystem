using AutoMapper;
using BlogSystem.Application.Contracts.Infrastructure;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Application.Models.Mail;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.CreateBlog
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
	{
		private readonly IBlogRepository _blogRepository;
		private readonly IMapper _mapper;
		private readonly IEmailService _emailService;

		public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper, IEmailService emailService)
		{
			_blogRepository = blogRepository;
			_mapper = mapper;
			_emailService = emailService;
		}

		public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			var @blog = _mapper.Map<Blog>(request);
			await ValidateRequest(request);
			@blog = await _blogRepository.AddAsync(@blog);
			var email = new Email { To = "ayvennro.d@gmail.com", Body = $"A new event was created: {request}", 
				Subject = "A new event was created" };
			try
			{
				await _emailService.SendEmailAsync(email);
			} 
			catch (Exception ex)
			{
				// this shouldn't stop the API from doing else so this can be logged
			}
			return @blog.Id;
		}

		private async Task ValidateRequest(CreateBlogCommand request)
		{
			var validator = new CreateBlogCommandValidator();
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Count > 0)
			{
				throw new Exceptions.ValidationException(validationResult);
			}
		}
	}
}
