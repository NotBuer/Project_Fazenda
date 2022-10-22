using Microsoft.EntityFrameworkCore;
using Project_Fazenda.Models;

namespace Project_Fazenda.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Animal>? Animais { get; set; }
        public DbSet<CompraGado>? CompraGado { get; set; }
        public DbSet<CompraGadoEm>? CompraGadoEm { get; set; }
        public DbSet<Pecuarista>? Pecuarista { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Pecuarista>().HasKey(c => c.IdPecuarista);
            mb.Entity<Pecuarista>().Property(c => c.NomePecuarista).HasMaxLength(100).IsRequired();

            mb.Entity<CompraGado>().HasKey(c => c.IdCompra);

            mb.Entity<Animal>().HasKey(c => c.IdAnimal);
            mb.Entity<Animal>().Property(c => c.DescricaoAnimal).HasMaxLength(500).IsRequired();

            mb.Entity<CompraGadoEm>().HasKey(c => c.IdCompraEm);
            mb.Entity<CompraGadoEm>().Property(c => c.Quantidade).HasMaxLength(999).IsRequired();

            mb.Entity<CompraGado>()
                .HasOne<Pecuarista>(c => c.Pecuarista)
                .WithMany(p => p.CompraGados)
                .HasForeignKey(c => c.IdCompra);

            mb.Entity<CompraGadoEm>()
                .HasOne<Animal>(c => c.Animal)
                .WithMany(p => p.CompraGadoEms)
                .HasForeignKey(c => c.IdAnimal);
        }
    }
}
