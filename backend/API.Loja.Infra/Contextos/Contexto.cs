using API.Loja.Dominio.Entidades;
using API.Loja.Utilitario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API.Loja.Infra.Contextos
{
    public class Contexto : DbContext
    {
        private readonly string BancoDeDados;

        public Contexto()
        {
            BancoDeDados = ConfiguracoesDaAplicacao.ObterStringDeConexaoBanco();
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(BancoDeDados, new MySqlServerVersion(new Version(8, 0, 29)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>();
            modelBuilder.Entity<Produtos>();


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
