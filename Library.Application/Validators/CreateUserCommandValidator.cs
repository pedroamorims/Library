using FluentValidation;
using Library.Application.Commands.CreateUser;

namespace Library.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email inválido");              
        }
    }
}
