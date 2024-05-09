﻿using System.ComponentModel.DataAnnotations;

namespace Vendagas.API.ORM.Entity
{
    public class UserModel
    {
        [Key]
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
