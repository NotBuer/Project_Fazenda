namespace Fazenda.Domain.Entities
{
    public class Pecuarista
    {
        public int Id { get; set; }

        [Required]
        public string NomePecuarista { get; set; }

        //[JsonIgnore]
        public ICollection<CompraGado>? CompraGados { get; set; }
    }
}
