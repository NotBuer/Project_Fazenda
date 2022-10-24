namespace Fazenda.Domain.Entities
{
    public class CompraGado
    {
        public int Id { get; set; }

        [Required]
        public int IdPecuarista { get; set; }

        [JsonIgnore]
        public Pecuarista? Pecuarista { get; set; }

        [JsonIgnore]
        public DateTime? DataEntrega { get; set; }
    }
}
