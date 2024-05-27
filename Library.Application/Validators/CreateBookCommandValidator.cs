using FluentValidation;
using Library.Application.Commands.CreateBook;

namespace Library.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .MaximumLength(100)
                .WithMessage("Título deve ter no máximo 100 caracteres");
        }
    }
}
