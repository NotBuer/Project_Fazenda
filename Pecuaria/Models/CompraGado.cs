using System;

namespace Pecuaria.Models
{
    public class CompraGado
    {
        public int Id { get; set; }
        public int IdPecuarista { get; set; }
        public Pecuarista Pecuarista { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
