using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendagas.API.Application.Services.PedidoProduto;
using Vendagas.API.ORM.Model.ProdutoPedido;

namespace Vendagas.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoService _pedidoProdutoService;

        public PedidoProdutoController(IPedidoProdutoService pedidoProdutoService)
        {
            _pedidoProdutoService = pedidoProdutoService;
        }

        [HttpGet("get-all-produto-pedido")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllEmpresas()
        {
            try
            {
                var produto_pedidos = _pedidoProdutoService.GetAllProdutoPedido();
                return Ok(produto_pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar empresas: {ex.Message}");
            }
        }


        [HttpPost("create-produto-pedido/{pedidoId}/{produtoId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateEmpresa(int pedidoId, int produtoId, ProdutoPedidoRequest produtoPedido)
        {
            try
            {
                var newProdutoPedido = _pedidoProdutoService.CreatePedidoProduto(produtoId, pedidoId, produtoPedido);
                return Ok(newProdutoPedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar o pedido do produto: {ex.Message}");
            }
        }

        [HttpGet("verificarPedidoExistente/{produtoId}/{pedidoId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult VerificarPedidoExistente(int produtoId, int pedidoId)
        {
            try
            {
                var pedidoExistente = _pedidoProdutoService.VerificarPedidoExistente(produtoId, pedidoId);
                return Ok(pedidoExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao verificar pedido existente: {ex.Message}");
            }
        }
    }
}
