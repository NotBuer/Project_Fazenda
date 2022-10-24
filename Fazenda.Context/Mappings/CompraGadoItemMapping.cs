namespace Fazenda.Context.Mappings
{
    public class CompraGadoItemMapping : IEntityTypeConfiguration<CompraGadoItem>
    {
        public void Configure(EntityTypeBuilder<CompraGadoItem> builder)
        {
            // Properties
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.IdCompraGado);
            builder.Property(c => c.IdAnimal);
            builder.Property(c => c.Quantidade).HasMaxLength(999).IsRequired();

            // Foreign Keys
            builder.HasOne(c => c.CompraGado)
                   .WithMany().HasForeignKey(fk => fk.IdCompraGado)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Animal)
                   .WithMany(c => c.CompraGadoItems)
                   .HasForeignKey(c => c.IdAnimal);
        }
    }
}
