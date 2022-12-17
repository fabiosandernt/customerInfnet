using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer.Domain.Cadastro.ValueObject
{
    public class Cnpj
    {
        public Cnpj()
        {

        }

        public Cnpj(string cnpj)
        {
            Valor = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
        }

        public string Valor { get; set; }
    }
}
