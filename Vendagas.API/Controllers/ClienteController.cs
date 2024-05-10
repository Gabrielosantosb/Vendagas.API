using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("get-all-clientes")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var clientes = _clienteService.GetAllClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }

        [HttpGet("get-clientes-by-empresa/{empresaId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetClienteByEmpresa(int empresaId)
        {
            try
            {
                var clientes = _clienteService.GetAllClientesByEmpresa(empresaId);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }

        [HttpPost("create-client/{empresaId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
