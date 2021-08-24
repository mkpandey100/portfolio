using FluentValidation;

namespace Portfolio.Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(250).NotEmpty();
            RuleFor(v => v.Email).MaximumLength(250).NotEmpty();
            RuleFor(v => v.Password).MinimumLength(5).MaximumLength(250).NotEmpty();
        }
    }
}
