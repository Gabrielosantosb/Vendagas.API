using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Empresa;
using Vendagas.API.ORM.Model.Produto;

namespace Vendagas.API.Application.Services.Produto
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoModel> GetAllProdutos();
        ProdutoModel GetProdutosById(int id);

        ProdutoModel CreateProduto(int empresaId, ProdutoModelRequest produtoRequest);

        void DeleteProduto(int produtoId);

    }
}
