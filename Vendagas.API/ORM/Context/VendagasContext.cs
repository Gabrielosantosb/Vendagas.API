﻿using Microsoft.EntityFrameworkCore;
using Vendagas.API.ORM.Entity;

namespace Vendagas.API.ORM.Context
{
    public class VendagasContext :DbContext
    {
        public VendagasContext(DbContextOptions<VendagasContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
    }
}
