using Customer.Domain.Account;
using Customer.Domain.Account.Repository;
using Customer.Repository.Context;
using Customer.Repository.Database;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repository.Repository
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CustomerContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarioPorId(Guid id)
        {
            return await this.Query.Where(x => x.Id == id).ToListAsync();
        }
    }
}
