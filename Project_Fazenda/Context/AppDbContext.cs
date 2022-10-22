using Microsoft.EntityFrameworkCore;
using Fazenda.Domain.Entities;

namespace Project_Fazenda.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Animal>? Animais { get; set; }
        public DbSet<CompraGado>? CompraGado { get; set; }
        public DbSet<CompraGadoItem>? CompraGadoEm { get; set; }
        public DbSet<Pecuarista>? Pecuarista { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Pecuarista>().HasKey(c => c.IdPecuarista);
            mb.Entity<Pecuarista>().Property(c => c.IdPecuarista).ValueGeneratedOnAdd();
            mb.Entity<Pecuarista>().Property(c => c.NomePecuarista).HasMaxLength(100).IsRequired();

            mb.Entity<CompraGado>().HasKey(c => c.IdCompra);
            mb.Entity<CompraGado>().Property(c => c.IdCompra).ValueGeneratedOnAdd();
            mb.Entity<CompraGado>()
                .HasOne(c => c.Pecuarista)
                .WithMany(p => p.CompraGados)
                .HasForeignKey(c => c.IdPecuarista);

            mb.Entity<Animal>().HasKey(c => c.IdAnimal);
            mb.Entity<Animal>().Property(c => c.IdAnimal).ValueGeneratedOnAdd();
            mb.Entity<Animal>().Property(c => c.DescricaoAnimal).HasMaxLength(500).IsRequired();

            mb.Entity<CompraGadoItem>().HasKey(c => c.IdCompraGadoItem);
            mb.Entity<CompraGadoItem>().Property(c => c.IdCompraGadoItem).ValueGeneratedOnAdd();
            mb.Entity<CompraGadoItem>().Property(c => c.Quantidade).HasMaxLength(999).IsRequired();

            // Foreign Keys
            mb.Entity<CompraGadoItem>().Property(c => c.IdCompraGado).HasColumnType("Int");
            mb.Entity<CompraGadoItem>()
                .HasOne(c => c.CompraGado)
                .WithMany().HasForeignKey(fk => fk.IdCompraGado)
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<CompraGadoItem>().Property(c => c.IdCompraGado).HasColumnType("Int");
            mb.Entity<CompraGadoItem>()
                .HasOne(c => c.Animal)
                .WithMany().HasForeignKey(fk => fk.IdAnimal)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
