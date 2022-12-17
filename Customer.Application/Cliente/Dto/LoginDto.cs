using MediatR;

namespace Customer.Application.Cliente.Dto
{
    public class LoginDto : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
