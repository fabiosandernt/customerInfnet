using Customer.CrossCutting.Repository;

namespace Customer.Domain.Account.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<IEnumerable<Usuario>> ObterUsuarioPorId(Guid id);


    }
}
