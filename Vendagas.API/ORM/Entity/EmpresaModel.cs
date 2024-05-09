﻿using System.ComponentModel.DataAnnotations;

namespace Vendagas.API.ORM.Entity
{
    public class EmpresaModel
    {

        [Key]
        public int EmpresaId { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        public UserModel User { get; set; }

    }
}
