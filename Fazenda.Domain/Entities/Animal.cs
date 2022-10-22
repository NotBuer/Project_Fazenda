namespace Fazenda.Domain.Entities
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string? DescricaoAnimal { get; set; }
        public decimal Preco { get; set; }

        public ICollection<CompraGadoItem>? CompraGadoEms { get; set; }
    }
}
