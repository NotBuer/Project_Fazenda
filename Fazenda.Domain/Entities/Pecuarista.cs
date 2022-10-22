namespace Fazenda.Domain.Entities
{
    public class Pecuarista
    {
        public int IdPecuarista { get; set; }
        public string? NomePecuarista { get; set; }

        public ICollection<CompraGado>? CompraGados { get; set; }
    }
}
