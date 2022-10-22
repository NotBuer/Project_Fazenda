namespace Project_Fazenda.Models
{
    public class CompraGadoItem
    {
        #region CompraGado
        public int IdCompraItem { get; set; }

        public int IdCompraGado { get; set; }
        public CompraGado? CompraGado { get; set; }

        public int IdAnimal { get; set; }
        public Animal? Animal { get; set; }

        public int? Quantidade { get; set; }
        #endregion
    }
}
