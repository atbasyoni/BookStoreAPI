using BookStore.Core.Features.Books.Commands;
using FluentValidation;

namespace BookStore.Core.Features.Books.Validators
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(b => b.ISBN)
                .NotEmpty().WithMessage("ISBN is required.")
                .Length(13).WithMessage("ISBN must be 13 characters long.");

            RuleFor(b => b.PublicationDate)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Publication date cannot be in the future.");

            RuleFor(b => b.Pages)
                .GreaterThan(0).WithMessage("Pages must be greater than zero.");
        }
    }
}
