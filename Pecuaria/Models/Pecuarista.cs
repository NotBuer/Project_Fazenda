using System.Collections.Generic;

namespace Pecuaria.Models
{
    public class Pecuarista
    {
        public int IdPecuarista { get; set; }
        public string NomePecuarista { get; set; }

        public ICollection<CompraGado> CompraGados { get; set; }
    }
}
