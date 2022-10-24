namespace Fazenda.Context.Mappings
{
    public class AnimalMapping : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.DescricaoAnimal).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Preco).IsRequired();
        }
    }
}
