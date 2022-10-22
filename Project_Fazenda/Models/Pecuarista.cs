namespace Project_Fazenda.Models
{
    public class Pecuarista
    {
        #region Pecuarista
        public int IdPecuarista { get; set; }
        public string? NomePecuarista { get; set; }

        public ICollection<CompraGado>? CompraGados { get; set; }
        #endregion
    }
}
