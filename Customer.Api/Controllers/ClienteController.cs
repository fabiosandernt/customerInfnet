using Customer.Application.Cliente.Handler.Command;
using Customer.Application.Cliente.Handler.Query;
using Customer.CrossCutting.JwtService.Contracts;
using Customer.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Customer.Application.Cliente.Dto.ClienteDto;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IJwtService _jwtService;

        public ClienteController(IMediator mediator, IJwtService jwtService)
        {
            this.mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await this.mediator.Send(new GetAllClienteQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetClienteQuery(id)));
        }


        [HttpPost()]
        public async Task<IActionResult> Criar(ClienteInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var jwtTokenVm = await _jwtService.ReadTokenAsync(token);
                if (jwtTokenVm is null) return Unauthorized();

                var result = await this.mediator.Send(new CreateClienteCommand(dto) { IdUsuario = jwtTokenVm.Id });
               
                return Created($"{result.Cliente.Id}", result.Cliente);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }

        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(ClienteInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateClienteCommand(dto));
            return Ok(result.Cliente);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(ClienteInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteClienteCommand(dto));
            return Ok(result.Cliente);
        }

    }
}
