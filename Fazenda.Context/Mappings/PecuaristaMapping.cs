namespace Fazenda.Context.Mappings
{
    public class PecuaristaMapping : IEntityTypeConfiguration<Pecuarista>
    {
        public void Configure(EntityTypeBuilder<Pecuarista> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.NomePecuarista).HasMaxLength(100).IsRequired();
        }
    }
}
