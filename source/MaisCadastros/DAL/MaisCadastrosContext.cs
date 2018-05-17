using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class MaisCadastrosContext : DbContext
    {
        public MaisCadastrosContext(DbContextOptions<MaisCadastrosContext> options)
            : base(options)
        {
        }

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
