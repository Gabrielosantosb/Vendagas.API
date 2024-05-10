using Microsoft.EntityFrameworkCore;
using Vendagas.API.ORM.Entity;

namespace Vendagas.API.ORM.Context
{
    public class VendagasContext :DbContext
    {
        public VendagasContext(DbContextOptions<VendagasContext> options) : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<EmpresaModel> Empresa { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
    }
}
