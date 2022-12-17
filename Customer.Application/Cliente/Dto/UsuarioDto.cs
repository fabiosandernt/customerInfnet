using Customer.Domain.Account.Enums;
using Customer.Domain.Account.ValueObject;
using System.ComponentModel.DataAnnotations;


namespace Customer.Application.Cliente.Dto
{
    public class UsuarioDto
    {
        public record UsuarioInputDto(
        Guid? Id,
        [Required(ErrorMessage = "O nome é requerido!")] string Nome,
        [Required(ErrorMessage = "o Tipo é requerido!")] TipoUsuarioEnum TipoUsuario,
        [Required(ErrorMessage = "A Senha é requerida!")] Password Password,
        [Required(ErrorMessage = "O Email é requerido!")] Email Email
    );

        public record UsuarioOutputDto(Guid Id, string Nome, TipoUsuarioEnum TipoUsuario, Email Email);
    }
}
