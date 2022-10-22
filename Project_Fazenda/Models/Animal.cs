namespace Project_Fazenda.Models
{
    public class Animal
    {
        #region Animal
        public int IdAnimal { get; set; }
        public string? DescricaoAnimal { get; set; }
        public decimal Preco { get; set; }

        public ICollection<CompraGadoItem>? CompraGadoEms { get; set; }
        #endregion
    }
}
