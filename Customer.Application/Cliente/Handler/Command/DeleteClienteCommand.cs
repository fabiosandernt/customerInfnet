using MediatR;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Handler.Command
{
    public class DeleteClienteCommand : IRequest<DeleteClienteCommandResponse>
    {
        public ClienteInputDto Cliente { get; set; }

        public Guid IdUsuario { get; set; }
        public DeleteClienteCommand(ClienteInputDto cliente)
        {
            Cliente = cliente;
        }
    }

    public class DeleteClienteCommandResponse
    {
        public ClienteOutputDto Cliente { get; set; }

        public DeleteClienteCommandResponse(ClienteOutputDto cliente)
        {
            Cliente = cliente;
        }
    }
}
