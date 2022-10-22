namespace Project_Fazenda.Models
{
    public class CompraGadoEm
    {
        #region CompraGado
        public int IdCompraEm { get; set; }

        public int IdCompraGado { get; set; }
        public CompraGado? CompraGado { get; set; }

        public int IdAnimal { get; set; }
        public Animal? Animal { get; set; }

        public int? Quantidade { get; set; }
        #endregion
    }
}
