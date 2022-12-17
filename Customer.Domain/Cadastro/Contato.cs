using Customer.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Cadastro
{
    public class Contato : Entity<Guid>   
    {
        public string Telefone { get; set; }
        public string NomeDoContato { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
