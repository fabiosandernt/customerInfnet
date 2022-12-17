using Customer.CrossCutting.Entity;

namespace Customer.Domain.Cadastro
{
    public class Fornecedor: Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public string CertificadoDigital { get; set; }
    }
}
