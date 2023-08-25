using FluentValidation;

namespace BlogSystem.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
