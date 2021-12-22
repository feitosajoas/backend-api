using FluentValidation;
using Site.Domain.Entities;

namespace Site.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MinimumLength(80)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazio.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MinimumLength(30)
                .WithMessage("A senha deve ter no mínimo 30 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")

                .MinimumLength(180)
                .WithMessage("O email deve ter no mínimo 180 caracteres.")

                // .Matches() // TODO: Inserir validação de email
                .WithMessage("O email informado não é válido");
        }
    }
}