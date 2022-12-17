using Customer.CrossCutting.JwtService.Dto;
using Customer.CrossCutting.JwtService.ViewModel;


namespace Customer.CrossCutting.JwtService.Contracts
{
    public interface IJwtService
    {
        ValueTask<string> GenerateToken(JwtDto jwtDto);
        ValueTask<JwtTokenViewModel> ReadTokenAsync(string token);
    }
}
