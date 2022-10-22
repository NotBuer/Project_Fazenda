namespace Fazenda.Domain.Interfaces.Repositories
{
    public interface ICompraGadoRepository
    {
        void Criar(CompraGado compraGado);
        void Atualizar(CompraGado compraGado);
        void Deletar(CompraGado compraGado);

        Task<int> Salvar();

        Task<List<CompraGado>> ObterCompraGado();
        Task<CompraGado> ObterCompraGadoPorId(int id);
    }
}
