using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.CreateBlog
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
	{
		private readonly IBlogRepository _blogRepository;
		private readonly IMapper _mapper;

		public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
		{
			_blogRepository = blogRepository;
			_mapper = mapper;
		}

		public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			var @blog = _mapper.Map<Blog>(request);
			var validator = new CreateBlogCommandValidator();
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Count > 0)
			{
				throw new Exceptions.ValidationException(validationResult);
			}
			@blog = await _blogRepository.AddAsync(@blog);
			return @blog.Id;
		}
	}
}
