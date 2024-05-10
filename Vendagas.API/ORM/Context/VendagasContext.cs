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
        public DbSet<ProdutoModel> Produto { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<ProdutoModel>()
                .HasIndex(p => p.EmpresaId)
                .IsUnique(false);
        }
    }
}
