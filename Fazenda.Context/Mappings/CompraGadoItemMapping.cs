namespace Fazenda.Context.Mappings
{
    public class CompraGadoItemMapping : IEntityTypeConfiguration<CompraGadoItem>
    {
        public void Configure(EntityTypeBuilder<CompraGadoItem> builder)
        {
            builder.HasKey(c => c.IdCompraGadoItem);
            builder.Property(c => c.IdCompraGadoItem).ValueGeneratedOnAdd();
            builder.Property(c => c.Quantidade).HasMaxLength(999).IsRequired();
            builder.Property(c => c.IdCompraGado);
            builder.HasOne(c => c.CompraGado)
                   .WithMany().HasForeignKey(fk => fk.IdCompraGado)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.IdCompraGado);
            builder.HasOne(c => c.Animal)
                   .WithMany().HasForeignKey(fk => fk.IdAnimal)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
