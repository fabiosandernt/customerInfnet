using Customer.Domain.Cadastro;
using Customer.Domain.Cadastro.Repository;
using Customer.Repository.Context;
using Customer.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repository.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CustomerContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            return await this.Query.Include(x => x.Cnpj).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientesPorCnpj(string cpf)
        {
            return await this.Query.Where(x => x.Cnpj.Valor == cpf).ToListAsync();  
        }
    }
}
