using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecuaria.Models
{
    public class AnimalCompraGadoItemOutput
    {
        public string NomeAnimal { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
