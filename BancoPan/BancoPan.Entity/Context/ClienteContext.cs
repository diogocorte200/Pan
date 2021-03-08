using BancoPan.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BancoPan.Entity.Context
{
    public partial class ClienteContext : DbContext
    {

        public ClienteContext(DbContextOptions<ClienteContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Endereco> enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
             .HasKey(x => x.Id);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
