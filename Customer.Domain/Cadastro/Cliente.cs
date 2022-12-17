using Customer.CrossCutting.Entity;
using Customer.Domain.Account;
using Customer.Domain.Cadastro.ValueObject;

namespace Customer.Domain.Cadastro
{

    public class Cliente : Entity<Guid>
    {
        protected Cliente() { }
        public string Nome { get; set; }
        public Cnpj Cnpj { get; set; }
        public IList<Contato> Contatos { get; set; }       
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cliente(string nome, string cnpj)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cnpj.Valor = cnpj;
        }

    }
}
