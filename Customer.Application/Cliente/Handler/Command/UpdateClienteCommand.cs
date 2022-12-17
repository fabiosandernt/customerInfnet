using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Handler.Command
{
    public class UpdateClienteCommand : IRequest<UpdateClienteCommandResponse>
    {
        public ClienteInputDto Cliente { get; set; }

        public Guid IdUsuario { get; set; }
        public UpdateClienteCommand(ClienteInputDto cliente)
        {
            Cliente = cliente;
        }
    }

    public class UpdateClienteCommandResponse
    {
        public ClienteOutputDto Cliente { get; set; }

        public UpdateClienteCommandResponse(ClienteOutputDto cliente)
        {
            Cliente = cliente;
        }
    }
}
