using System.Collections.Generic;

namespace Pecuaria.Models
{
    public class Pecuarista
    {
        public int Id { get; set; }
        public string NomePecuarista { get; set; }

        public ICollection<CompraGado> CompraGados { get; set; }
    }
}
