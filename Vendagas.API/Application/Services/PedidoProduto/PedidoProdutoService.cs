using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.ProdutoPedido;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.PedidoProduto
{
    public class PedidoProdutoService : IPedidoProdutoService
    {
        private readonly BaseRepository<PedidoProdutoModel> _pedidoProdutoRepository;

        public PedidoProdutoService(BaseRepository<PedidoProdutoModel> pedidoProdutoRepository)
        {
            _pedidoProdutoRepository = pedidoProdutoRepository;
        }

        public PedidoProdutoModel CreatePedidoProduto(int produtoId, int pedidoId, ProdutoPedidoRequest produtoPedidoRequest)
        {
            if(produtoId == null || pedidoId == null || produtoPedidoRequest == null)
            {
                throw new ArgumentNullException(nameof(produtoPedidoRequest));
            }
            var newPedidoProduto = new PedidoProdutoModel
            {
                Quantidade = produtoPedidoRequest.Quantidade,
                PedidoId = pedidoId,
                ProdutoId = produtoId                
            };
            var createdPedidoProduto = _pedidoProdutoRepository.Add(newPedidoProduto);
            _pedidoProdutoRepository.SaveChanges();
            return createdPedidoProduto;
        }

        public IEnumerable<PedidoProdutoModel> GetAllProdutoPedido()
        {
            return _pedidoProdutoRepository.GetAll();
        }

        public PedidoProdutoModel GetPedidoProdutoById(int id)
        {
            var pedido_produto = _pedidoProdutoRepository.GetAll().FirstOrDefault(p => p.Pedido_ProdutoId == id);
            return pedido_produto;
        }
    }
}
