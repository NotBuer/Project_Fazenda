namespace Fazenda.Context.Mappings
{
    public class CompraGadoMapping : IEntityTypeConfiguration<CompraGado>
    {
        public void Configure(EntityTypeBuilder<CompraGado> builder)
        {
            builder.HasKey(c => c.IdCompra);
            builder.Property(c => c.IdCompra).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Pecuarista)
                .WithMany(p => p.CompraGados)
                .HasForeignKey(fk => fk.IdPecuarista);
        }
    }
}
