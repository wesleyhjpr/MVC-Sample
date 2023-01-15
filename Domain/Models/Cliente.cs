using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public override ValidationResult Validar()
        {
            return new ClienteValidation().Validate(this);
        }
    }
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(m => m.Nome)
                    .NotEmpty()
                    .Length(3,30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
