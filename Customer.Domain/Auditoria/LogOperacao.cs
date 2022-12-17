using Customer.CrossCutting.Entity;
using Customer.Domain.Account;

namespace Customer.Domain.Auditoria
{
    public class LogOperacao : Entity<Guid>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
