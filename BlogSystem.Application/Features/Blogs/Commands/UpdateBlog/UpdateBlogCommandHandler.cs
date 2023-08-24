using AutoMapper;
using BlogSystem.Application.Contracts.Persistence;
using BlogSystem.Domain.Entities;
using MediatR;

namespace BlogSystem.Application.Features.Blogs.Commands.UpdateBlog
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IGenericAsyncRepository<Blog> _blogRepository;
		private readonly IMapper _mapper;

		public UpdateBlogCommandHandler(IGenericAsyncRepository<Blog> blogRepository, IMapper mapper)
		{
			_blogRepository = blogRepository;
			_mapper = mapper;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var blogToUpdate = await _blogRepository.GetByIdAsync(request.Id);
			_mapper.Map(request, blogToUpdate, typeof(UpdateBlogCommand), typeof(Blog));
			await _blogRepository.UpdateAsync(blogToUpdate);
			return;
		}
	}
}
