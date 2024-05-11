using Microsoft.EntityFrameworkCore;
using Vendagas.API.ORM.Context;
using Vendagas.API.ORM.Entity;
using Vendagas.API.ORM.Model.Produto;
using Vendagas.API.ORM.Repository;

namespace Vendagas.API.Application.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly BaseRepository<ProdutoModel> _produtoRepository;
        private readonly VendagasContext _context;


        public ProdutoService(BaseRepository<ProdutoModel> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoModel CreateProduto(int empresaId, ProdutoModelRequest produtoRequest)
        {

            if (produtoRequest == null)
            {
                throw new ArgumentNullException(nameof(produtoRequest));
            }


            var newProduto = new ProdutoModel
            {
                EmpresaId = empresaId,
                Descricao = produtoRequest.Descricao,
                Nome = produtoRequest.Nome,
                Valor = produtoRequest.Valor,
            };
            var createdProduto = _produtoRepository.Add(newProduto);
            _produtoRepository.SaveChanges();
            return createdProduto;
        }

        public IEnumerable<ProdutoModel> GetAllProdutos()
        {
            return _produtoRepository._context.Produto.Include(p => p.Empresa).ToList();
        }

        public ProdutoModel GetProdutosById(int id)
        {
            var produto = _produtoRepository.GetById(id);
            return produto;
        }
    }
}
