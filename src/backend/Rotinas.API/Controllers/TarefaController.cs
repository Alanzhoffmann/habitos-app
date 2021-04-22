using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rotinas.Domain.DTO;

namespace Rotinas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ISender _sender;

        public TarefaController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public Task<ListaTarefaViewModel> BuscarTarefas()
        {
            var command = new BuscarListaTarefasCommand();

            return _sender.Send(command); 
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] SalvarTarefaCommand command)
        {
            await _sender.Send(command);

            return Ok();
        }
    }
}
