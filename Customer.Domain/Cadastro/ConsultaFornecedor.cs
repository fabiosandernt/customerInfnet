using Customer.CrossCutting.Entity;
using Customer.Domain.Account;

namespace Customer.Domain.Cadastro
{
    public class ConsultaFornecedor: Entity<Guid>
    {
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
