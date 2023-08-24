using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.DeleteBlog
{
	public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
	{
		private readonly IGenericAsyncRepository<Blog> _blogRepository;
		private readonly IMapper _mapper;

		public DeleteBlogCommandHandler(IGenericAsyncRepository<Blog> blogRepository, IMapper mapper)
		{
			_blogRepository = blogRepository;
			_mapper = mapper;
		}

		public async Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
		{
			var blogToDelete = await _blogRepository.GetByIdAsync(request.Id);
			await _blogRepository.DeleteAsync(blogToDelete);
			return;
		}
	}
}
