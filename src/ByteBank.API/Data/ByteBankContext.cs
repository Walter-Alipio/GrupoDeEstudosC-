using ByteBank.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Data
{
    public class ByteBankContext : IdentityDbContext
    {
        public ByteBankContext(DbContextOptions<ByteBankContext> options)
            : base(options)
        {
        }

        public DbSet<Conta> Contas { get; set; } = null!;

        public DbSet<Agencia> Agencias { get; set; } = null!;

        public DbSet<Cliente> Clientes { get; set; } = null!;

        public DbSet<EnderecoAgencia> EnderecosAgencia { get; set; } = null!;

        public DbSet<EnderecoCliente> EnderecosCliente { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionado para cria��o da migra��o.
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ByteBankContext).Assembly);
        }
    }
}