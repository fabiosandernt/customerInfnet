using Customer.Application.Cliente.Dto;
using Customer.Application.Cliente.Handler.Command;
using Customer.Application.Cliente.Handler.Query;
using Customer.Application.Cliente.Service;
using MediatR;

namespace Customer.Application.Cliente.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                  IRequestHandler<UpdateUsuarioCommand, UpdateUsuarioCommandResponse>,
                                  IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioCommandResponse>,
                                  IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>,
                                  IRequestHandler<GetUsuarioQuery, GetUsuarioQueryResponse>,
                                  IRequestHandler<LoginDto, string>

    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Criar(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<UpdateUsuarioCommandResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Atualizar(request.Usuario);
            return new UpdateUsuarioCommandResponse(result);
        }

        public async Task<DeleteUsuarioCommandResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.Deletar(request.Usuario);
            return new DeleteUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioService.ObterTodos();
            return new GetAllUsuarioQueryResponse(result);
        }

        public async Task<GetUsuarioQueryResponse> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.ObterPorId(request.IdUsuario);
            return new GetUsuarioQueryResponse(result);
        }

        public async Task<string> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            return await _usuarioService.ObterTokenJwtAsync(request);
        }
    }
}
