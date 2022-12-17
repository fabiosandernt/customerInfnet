using Customer.Application.Cliente.Handler.Command;
using Customer.Application.Cliente.Handler.Query;
using Customer.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Customer.Application.Cliente.Dto.UsuarioDto;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.mediator.Send(new GetAllUsuarioQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}/ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            var result = await this.mediator.Send(new GetUsuarioQuery(id));

            return result?.Usuario is null ? NotFound() : Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Criar([FromBody] UsuarioInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
                return Created($"{result.Usuario.Id}", result.Usuario);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar([FromBody] UsuarioInputDto dto)
        {
            if (dto is null) return UnprocessableEntity();

            try
            {
                var result = await this.mediator.Send(new UpdateUsuarioCommand(dto));
                return Ok(result.Usuario);
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponseError(e.Message));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Apagar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteUsuarioCommand(dto));
            return Ok(result.Usuario);
        }
    }
}
