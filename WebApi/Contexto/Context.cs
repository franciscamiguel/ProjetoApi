using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;

namespace WebApi.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConect());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetStringConect()
        {
            return "Data Source=LAPTOP-6JHREI2F\\SQLEXPRESS;Initial Catalog=CADASTRO_FRA;Integrated Security=True";
           // return "Data Source=192.168.0.101,1433;Initial Catalog=CADASTRO_FRA;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
