using Customer.Domain.Account;

using static Customer.Application.Cliente.Dto.UsuarioDto;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Application.Cliente.Profile
{
    public class CustomerProfile: AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<UsuarioInputDto, Usuario>();

            CreateMap<Usuario, UsuarioOutputDto>();

            CreateMap<ClienteInputDto, Customer.Domain.Cadastro.Cliente>();

            CreateMap<Customer.Domain.Cadastro.Cliente, ClienteOutputDto>();
        }        
                    
    }
}
