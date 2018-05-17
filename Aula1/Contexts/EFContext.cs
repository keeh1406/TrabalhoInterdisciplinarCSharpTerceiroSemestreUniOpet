using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aula1.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>()); }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}