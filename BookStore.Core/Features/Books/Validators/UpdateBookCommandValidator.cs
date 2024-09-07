using BookStore.Core.Features.Books.Commands;
using FluentValidation;

namespace BookStore.Core.Features.Books.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid book ID.");

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN is required.")
                .Length(13).WithMessage("ISBN must be 13 characters long.");

            RuleFor(x => x.PublicationDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Publication date cannot be in the future.");

            RuleFor(x => x.Pages)
                .GreaterThan(0).WithMessage("Pages must be greater than zero.");
        }
    }
}
