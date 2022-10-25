using Microsoft.EntityFrameworkCore;

namespace Fazenda.Repository
{
    public class PecuaristaRepository : IPecuaristaRepository
    {
        public readonly ApplicationDbContext _contexto;

        public PecuaristaRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Criar(Pecuarista pecuarista)
        {
            _contexto.Pecuarista.Add(pecuarista);
        }

        public void Atualizar(Pecuarista pecuarista)
        {
            _contexto.Pecuarista.Update(pecuarista);
        }

        public void Deletar(Pecuarista pecuarista)
        {
            _contexto.Pecuarista.Remove(pecuarista);
        }

        public async Task<int> Salvar()
        {
            return await _contexto.SaveChangesAsync();
        }

        public async Task<List<Pecuarista>> ObterPecuaristas()
        {
            var response = await _contexto.Pecuarista.ToListAsync();
            return response;
        }

        public async Task<Pecuarista> ObterPecuaristaPorId(int id)
        {
            var response = await _contexto.Pecuarista.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

        public async Task<Pecuarista> ObterPecuaristaPorNome(string nome)
        {
            var response = await _contexto.Pecuarista.Where(e => e.NomePecuarista == nome).FirstAsync();
            return response;
        }
    }
}
