using MediatR;

using static Customer.Application.Cliente.Dto.UsuarioDto;

namespace Customer.Application.Cliente.Handler.Query
{
    public class GetAllUsuarioQuery : IRequest<GetAllUsuarioQueryResponse>
    {
    }

    public class GetAllUsuarioQueryResponse
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public GetAllUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
    
}
