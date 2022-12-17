using Customer.CrossCutting.Entity;

namespace Customer.Domain.Cadastro
{
    public class TarifaContrato : Entity<Guid>
    {
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public double Valor { get; set; }
    }
}
