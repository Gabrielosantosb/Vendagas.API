using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Produto;
using Vendagas.API.ORM.Model.ProdutoPedido;

namespace Vendagas.API.Application.Services.PedidoProduto
{
    public interface IPedidoProdutoService
    {
        ProdutoModel CreatePedidoProduto(int produtoId, int pedidoId, ProdutoPedidoRequest produtoPedidoRequest);
    }
}
