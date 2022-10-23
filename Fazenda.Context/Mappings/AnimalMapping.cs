namespace Fazenda.Context.Mappings
{
    public class AnimalMapping : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(c => c.IdAnimal);
            builder.Property(c => c.IdAnimal).ValueGeneratedOnAdd();
            builder.Property(c => c.DescricaoAnimal).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Preco).IsRequired();
        }
    }
}
