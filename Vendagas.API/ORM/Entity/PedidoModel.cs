using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vendagas.API.ORM.Entity
{
    public class PedidoModel
    {
        [Key]
        public int PedidoId { get; set; }
        public int Numero { get; set; }
        
        public string Observacao { get; set; }
        public string Cliente { get; set; }
        public DateTime Data { get; set; }


        [JsonIgnore]
        public List<PedidoProdutoModel> Pedidos_Produtos { get; set; }

        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        //[JsonIgnore]
        public EmpresaModel Empresa { get; set; }
    }
}
