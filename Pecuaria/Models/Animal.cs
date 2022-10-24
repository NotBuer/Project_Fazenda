using System.Collections.Generic;

namespace Pecuaria.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string DescricaoAnimal { get; set; }
        public decimal Preco { get; set; }
        public ICollection<CompraGadoItem> CompraGadoItems { get; set; }
    }
}
