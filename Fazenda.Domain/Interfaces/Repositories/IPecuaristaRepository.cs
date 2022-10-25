namespace Fazenda.Domain.Interfaces.Repositories
{
    public interface IPecuaristaRepository
    {
        void Criar(Pecuarista pecuarista);
        void Atualizar(Pecuarista pecuarista);
        void Deletar(Pecuarista pecuarista);

        Task<int> Salvar();

        Task<List<Pecuarista>> ObterPecuaristas();
        Task<Pecuarista> ObterPecuaristaPorId(int id);
        Task<Pecuarista> ObterPecuaristaPorNome(string nome);
    }
}
