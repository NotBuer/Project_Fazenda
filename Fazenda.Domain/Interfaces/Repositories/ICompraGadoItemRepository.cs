namespace Fazenda.Domain.Interfaces.Repositories
{
    public interface ICompraGadoItemRepository
    {
        void Criar(CompraGadoItem compraGadoItem);
        void Atualizar(CompraGadoItem compraGadoItem);
        void Deletar(CompraGadoItem compraGadoItem);

        Task<int> Salvar();

        Task<List<CompraGadoItem>> ObterCompraGadoItem();
        Task<CompraGadoItem> ObterCompraGadoItemPorId(int id);
    }
}
