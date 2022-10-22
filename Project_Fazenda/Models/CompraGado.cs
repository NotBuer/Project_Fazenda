namespace Project_Fazenda.Models
{
    public class CompraGado
    {
        #region CompraGado
        public int IdCompra { get; set; }

        public int IdPecuarista { get; set; }
        public Pecuarista? Pecuarista { get; set; }

        public DateTime? DataEntrega { get; set; }

        #endregion
    }
}
