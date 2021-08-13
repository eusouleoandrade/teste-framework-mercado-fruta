using System.Threading.Tasks;
using MercadoFrutas.Core.Application.Features.Frutas.Commands.CreateFruta;
using MercadoFrutas.Core.Application.Features.Frutas.Commands.DeleteFrutaById;
using MercadoFrutas.Core.Application.Features.Frutas.Commands.UpdateFruta;
using MercadoFrutas.Core.Application.Features.Frutas.Queries.GetAllFrutas;
using MercadoFrutas.Core.Application.Features.Frutas.Queries.GetFrutaById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoFrutas.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FrutaController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFrutasParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllFrutasQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFrutaByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> Post(CreateFrutaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateFrutaCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFrutaByIdCommand { Id = id }));
        }
    }
}