using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets representam as tabelas no banco de dados
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        // Adicione outros DbSets conforme necessário, como Cliente, ItemVenda, etc.

        // Configuração adicional (como relacionamentos, chaves primárias compostas, etc.) pode ser feita aqui
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais para as entidades, como chaves estrangeiras, tabelas, etc.

            modelBuilder.Entity<ItemVenda>()
              .HasOne(i => i.Produto)
              .WithMany()
              .HasForeignKey(i => i.ProdutoId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(i => i.Venda)
                .WithMany(v=> v.ItensVenda)
                .HasForeignKey(i => i.VendaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
