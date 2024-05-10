using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vendagas.API.ORM.Entity
{
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }
        public string Valor {  get; set; }
        public string Descricao { get; set; }

        //[ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public EmpresaModel Empresa { get; set; }
    }
}
