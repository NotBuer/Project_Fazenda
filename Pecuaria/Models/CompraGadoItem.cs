namespace Pecuaria.Models
{
    public class CompraGadoItem
    {
        public int IdCompraGadoItem { get; set; }

        public int IdCompraGado { get; set; }
        public CompraGado CompraGado { get; set; }

        public int IdAnimal { get; set; }
        public Animal Animal { get; set; }

        public int? Quantidade { get; set; }
    }
}
