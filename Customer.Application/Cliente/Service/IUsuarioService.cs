using Customer.Application.Cliente.Dto;
using static Customer.Application.Cliente.Dto.UsuarioDto;

namespace Customer.Application.Cliente.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> ObterPorId(Guid id);
        Task<string> ObterTokenJwtAsync(LoginDto dto);
    }
}
