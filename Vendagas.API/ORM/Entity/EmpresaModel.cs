using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vendagas.API.ORM.Entity
{
    public class EmpresaModel
    {

        [Key]
        public int EmpresaId { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }


        public List<ClienteModel> Cliente { get; set; }

        [JsonIgnore]
        public UserModel User { get; set; }

    }
}
