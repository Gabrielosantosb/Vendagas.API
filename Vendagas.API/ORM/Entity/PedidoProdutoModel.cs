using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vendagas.API.ORM.Entity
{
    public class PedidoProdutoModel
    {
        [Key]
        public int Pedido_ProdutoId { get; set; }
        public int Quantidade { get; set; }
        
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public ProdutoModel Produto { get; set; }
        public int PedidoId { get; set; }
        [JsonIgnore]
        public PedidoModel Pedido { get; set; }

    }
}
