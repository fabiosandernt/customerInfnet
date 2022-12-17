using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Customer.Application.Cliente.Dto.UsuarioDto;

namespace Customer.Application.Cliente.Handler.Command
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public DeleteUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class DeleteUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public DeleteUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
