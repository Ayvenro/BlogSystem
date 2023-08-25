using FluentValidation;

namespace BlogSystem.Application.Features.Blogs.Commands.CreateBlog
{
	public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
	{
        public CreateBlogCommandValidator()
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
            RuleFor(b => b.Content).NotEmpty().WithMessage("{PropertyName is required.")
                .NotNull().MaximumLength(6000).WithMessage("{PropertyName} must not exceed 6000 characters");
        }
    }
}
