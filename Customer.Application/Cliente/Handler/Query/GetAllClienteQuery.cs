using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Handler.Query
{
    public class GetAllClienteQuery : IRequest<GetAllClienteQueryResponse>
    {
    }

    public class GetAllClienteQueryResponse
    {
        public IList<ClienteOutputDto> Clientes { get; set; }
        public GetAllClienteQueryResponse(IList<ClienteOutputDto> clientes)
        {
            Clientes = clientes;
        }
    }
}
