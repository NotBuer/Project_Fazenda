namespace Fazenda.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalMapping());
            modelBuilder.ApplyConfiguration(new CompraGadoMapping());
            modelBuilder.ApplyConfiguration(new CompraGadoItemMapping());
            modelBuilder.ApplyConfiguration(new PecuaristaMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<CompraGado> CompraGado { get; set; }
        public DbSet<CompraGadoItem> CompraGadoItem { get; set; }
        public DbSet<Pecuarista> Pecuarista { get; set; }
    }
}
