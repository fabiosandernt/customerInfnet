using Customer.Application.Cliente.Handler.Command;
using Customer.Application.Cliente.Handler.Query;
using Customer.Application.Cliente.Service;
using MediatR;


namespace Customer.Application.Cliente.Handler
{
    public class ClienteHandler : IRequestHandler<CreateClienteCommand, CreateClienteCommandResponse>,
                                  IRequestHandler<UpdateClienteCommand, UpdateClienteCommandResponse>,
                                  IRequestHandler<DeleteClienteCommand, DeleteClienteCommandResponse>,
                                  IRequestHandler<GetAllClienteQuery, GetAllClienteQueryResponse>,
                                  IRequestHandler<GetClienteQuery, GetClienteQueryResponse>
    {
        private readonly IClienteService _clienteService;

        public ClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<CreateClienteCommandResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await this._clienteService.Criar(request.Cliente, request.IdUsuario);
            return new CreateClienteCommandResponse(result);
        }

        public async Task<UpdateClienteCommandResponse> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await this._clienteService.Atualizar(request.Cliente, request.IdUsuario);
            return new UpdateClienteCommandResponse(result);
        }

        public async Task<DeleteClienteCommandResponse> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await this._clienteService.Deletar(request.Cliente, request.IdUsuario);
            return new DeleteClienteCommandResponse(result);
        }
        public async Task<GetAllClienteQueryResponse> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            var result = await this._clienteService.ObterTodos();
            return new GetAllClienteQueryResponse(result);
        }
        public async Task<GetClienteQueryResponse> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var result = await this._clienteService.ObterPorId(request.IdCliente);
            return new GetClienteQueryResponse(result);
        }

    }
}
