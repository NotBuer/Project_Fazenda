namespace Fazenda.Domain.Entities
{
    public class CompraGadoItem
    {
        public int Id { get; set; }

        [Required]
        public int IdCompraGado { get; set; }

        //[JsonIgnore]
        public CompraGado? CompraGado { get; set; }

        [Required]
        public int IdAnimal { get; set; }

        //[JsonIgnore]
        public Animal? Animal { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
