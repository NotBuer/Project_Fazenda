namespace Project_Fazenda.Models
{
    public class Animal
    {
        #region Animal
        public int IdAnimal { get; set; }
        public string? DescricaoAnimal { get; set; }
        public decimal Preco { get; set; }

        public ICollection<CompraGadoEm>? CompraGadoEms { get; set; }
        #endregion
    }
}
