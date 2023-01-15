using FluentValidation.Results;

namespace DevIO.Domain.Models
{
    public abstract class Validacao
    {
        public virtual ValidationResult Validar()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Entity : Validacao
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
