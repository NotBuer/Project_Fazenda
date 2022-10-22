using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Context.Mappings
{
    public class PecuaristaMapping : IEntityTypeConfiguration<Pecuarista>
    {
        public void Configure(EntityTypeBuilder<Pecuarista> builder)
        {
            builder.HasKey(c => c.IdPecuarista);
            builder.Property(c => c.IdPecuarista).ValueGeneratedOnAdd();
            builder.Property(c => c.NomePecuarista).HasMaxLength(100).IsRequired();
        }
    }
}
