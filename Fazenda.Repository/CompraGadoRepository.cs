namespace Fazenda.Repository
{
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CompraGadoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Criar(CompraGado compraGado)
        {
            _contexto.CompraGado.Add(compraGado);
        }

        public void Atualizar(CompraGado compraGado)
        {
            _contexto.CompraGado.Update(compraGado);
        }

        public void Deletar(CompraGado compraGado)
        {
            _contexto.CompraGado.Remove(compraGado);
        }

        public async Task<int> Salvar()
        {
            return await _contexto.SaveChangesAsync();
        }

        public async Task<List<CompraGado>> ObterCompraGado()
        {
            var response = await _contexto.CompraGado.ToListAsync();
            return response;
        }

        public async Task<CompraGado> ObterCompraGadoPorId(int id)
        {
            var response = await _contexto.CompraGado.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

    }
}
