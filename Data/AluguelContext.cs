using Microsoft.EntityFrameworkCore;
using BikeRack.Models;

namespace BikeRack.Data
{
    public class AluguelContext: DbContext
    {
        public AluguelContext(DbContextOptions<AluguelContext> options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciclista>()
                .HasOne(c => c.CartaoDeCredito)
                .WithOne()
                .HasForeignKey<CartaoDeCredito>(c => c.CiclistaId);

            modelBuilder.Entity<Ciclista>()
                .HasOne(c => c.Passaporte)
                .WithOne()
                .HasForeignKey<Passaporte>(p => p.CiclistaId);

            modelBuilder.Entity<Ciclista>()
                .HasMany<GestaoAluguel>()
                .WithOne()
                .HasForeignKey(g => g.Ciclista);

            modelBuilder.Entity<CartaoDeCredito>()
                .HasMany<GestaoAluguel>()
                .WithOne()
                .HasForeignKey(g => g.CartaoDeCredito);

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.Property(f => f.Matricula)
                    .ValueGeneratedOnAdd();
            });
            
        }

        public DbSet<Ciclista> Ciclistas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<GestaoAluguel> GestaoAluguel { get; set; }

        public DbSet<CartaoDeCredito> CartoesDeCredito { get; set; }

        public DbSet<Passaporte> Passaportes { get; set; }



    }
}
