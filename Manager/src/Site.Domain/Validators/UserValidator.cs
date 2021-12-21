using FluentValidation;

namespace Site.Domain.Validators
{
    public class UserValidator : AbstracValidator<User>
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

                .MinimunLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MinimunLength(80)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .MinimunLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")

                .MinimunLength(180)
                .WithMessage("O email deve ter no mínimo 180 caracteres.")

                .Matches() // TODO: Inserir validação de email
                .WithMessage("O email informado não é válido");
        }
    }
}