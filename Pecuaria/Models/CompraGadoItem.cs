namespace Pecuaria.Models
{
    public class CompraGadoItem
    {
        public int Id { get; set; }

        public int IdCompraGado { get; set; }
        public CompraGado CompraGado { get; set; }

        public int IdAnimal { get; set; }
        public Animal Animal { get; set; }

        public int Quantidade { get; set; }
    }
}
