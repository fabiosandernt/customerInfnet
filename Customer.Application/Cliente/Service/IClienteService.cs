using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Service
{
    public interface IClienteService
    {
        Task<ClienteOutputDto> Criar(ClienteInputDto dto, Guid usuarioId);
        Task<List<ClienteOutputDto>> ObterTodos();
        Task<ClienteOutputDto> Atualizar(ClienteInputDto dto, Guid usuarioId);
        Task<ClienteOutputDto> Deletar(ClienteInputDto dto, Guid usuarioId);
        Task<ClienteOutputDto> ObterPorId(Guid id);
    }
}
