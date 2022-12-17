
using Customer.Domain.Cadastro;

namespace Customer.Application.Cliente.Dto
{
    public class ClienteDto
    {
        public record ClienteInputDto(string Nome, string Cnpj, Contato Contato);
        public record ClienteOutputDto(Guid Id, string Nome, string Cnpj, Contato Contato);
    }
}
