using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.Empresa;
using Vendagas.API.Application.Services.Pedido;
using Vendagas.API.ORM.Model.Empresa;
using Vendagas.API.ORM.Model.Pedido;

namespace Vendagas.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpGet("get-all-pedidos")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var pedidos = _pedidoService.GetAllPedidos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }

        [HttpPost("create-pedido/{empresaId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateEmpresa(int empresaId, PedidoRequestModel pedidoRequest)
        {
            try
            {
                var novaEmpresa = _pedidoService.CreatePedido(empresaId, pedidoRequest);
                return Ok(novaEmpresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar empresa: {ex.Message}");
            }
        }

        [HttpGet("get-pedido/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEmpresaById(int id)
        {
            try
            {
                var empresa = _pedidoService.GetPedidoById(id);
                if (empresa == null)
                {
                    return NotFound($"Pedido com o ID {id} não encontrada");
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresa: {ex.Message}");
            }
        }


    }
}
