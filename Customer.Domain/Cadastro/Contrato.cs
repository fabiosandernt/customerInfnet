using Customer.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Cadastro
{
    public class Contrato: Entity<Guid>
    {
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FimVigencia { get; set; }
        public IList<TarifaContrato> TarifaContratos { get; set; }

    }
}
