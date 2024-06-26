﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vendagas.API.ORM.Entity
{
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }
        public string ClienteName { get; set;}
        public string Email { get; set;}
        public string Telefone { get; set;}

        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }
        //[JsonIgnore]
        public EmpresaModel Empresa { get; set; }
    }
}
