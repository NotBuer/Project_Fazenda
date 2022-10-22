namespace Fazenda.Domain.Entities
{
    public class CompraGado
    {
        public int IdCompra { get; set; }

        public int IdPecuarista { get; set; }
        public Pecuarista? Pecuarista { get; set; }

        public DateTime? DataEntrega { get; set; }
    }
}
