namespace Fazenda.Domain.Entities
{
    public class Animal
    {

        public int Id { get; set; }

        [Required]
        public string NomeAnimal { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [JsonIgnore]
        public ICollection<CompraGadoItem>? CompraGadoItems { get; set; }
    }
}
