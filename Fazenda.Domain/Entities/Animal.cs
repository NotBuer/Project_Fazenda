using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fazenda.Domain.Entities
{
    public class Animal
    {

        public int IdAnimal { get; set; }

        [Required]
        public string DescricaoAnimal { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [JsonIgnore]
        public ICollection<CompraGadoItem>? CompraGadoItems { get; set; }
    }
}
