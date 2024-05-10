using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.Cliente;
using Vendagas.API.ORM.Model.Cliente;

namespace Vendagas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("create-client/{empresaId}")]
        public IActionResult CreateCliente(int empresaId, [FromBody] ClienteRequest clienteRequest)
        {
            if (clienteRequest == null)
            {
                return BadRequest("Dados Inválidos");
            }
            var createdCliente = _clienteService.CreateCliente(empresaId, clienteRequest);
            if (createdCliente != null)
            {
                return Ok(createdCliente);
            }
            return BadRequest();
        }
    }
}
