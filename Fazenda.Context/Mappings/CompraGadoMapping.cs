namespace Fazenda.Context.Mappings
{
    public class CompraGadoMapping : IEntityTypeConfiguration<CompraGado>
    {
        public void Configure(EntityTypeBuilder<CompraGado> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Pecuarista)
                .WithMany(p => p.CompraGados)
                .HasForeignKey(fk => fk.IdPecuarista);
        }
    }
}
