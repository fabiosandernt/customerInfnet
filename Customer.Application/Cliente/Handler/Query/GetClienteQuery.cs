using MediatR;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Handler.Query
{
    public class GetClienteQuery : IRequest<GetClienteQueryResponse>
    {
        public Guid IdCliente { get; set; }

        public GetClienteQuery(Guid idCliente)
        {
            IdCliente = idCliente;
        }
    }

    public class GetClienteQueryResponse
    {
        public ClienteOutputDto Cliente { get; set; }
        public GetClienteQueryResponse(ClienteOutputDto cliente)
        {
            Cliente = cliente;
        }
    }
}
