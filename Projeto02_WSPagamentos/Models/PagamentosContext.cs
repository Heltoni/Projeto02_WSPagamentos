using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto02_WSPagamentos.Models
{
    public class PagamentosContext : DbContext
    {

        public PagamentosContext() : 
            base("name=PagamentosEntities"){}

        //AO UTILIZAR ESTE METODO NÃO PRECISAMOS UTILIZAR O TABLE NAS MODELS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .ToTable("TBClientes");

            modelBuilder.Entity<Cliente>().Property(c => c.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(c => c.NumeroCartao)
                .HasMaxLength(16)
                .IsRequired();
            
            modelBuilder.Entity<Pagamento>()
                .ToTable("TBPagamentos");

            modelBuilder.Entity<Pagamento>().Property(p => p.NumeroCartao)
                .HasMaxLength(16)
                .IsRequired();

            modelBuilder.Entity<Pagamento>().Property(p => p.NumeroPedido)                
                .HasMaxLength(10)
                .IsRequired();

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

    }
}