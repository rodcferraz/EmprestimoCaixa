using EmprestimoCaixa.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoCaixa.Infraestrutura.Data
{
    public class EmprestimoCaixaDbContext : DbContext
    {
        public EmprestimoCaixaDbContext(DbContextOptions<EmprestimoCaixaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos => Set<Produto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais (opcional)
            modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto);
            modelBuilder.Entity<Produto>().Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.TaxaJurosAnual).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.PrazoMaximoMeses).IsRequired();
        }
    }
}