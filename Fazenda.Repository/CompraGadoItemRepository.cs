namespace Fazenda.Repository
{
    public class CompraGadoItemRepository : ICompraGadoItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CompraGadoItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }


        public void Criar(CompraGadoItem compraGadoItem)
        {
            _contexto.CompraGadoItem.Add(compraGadoItem);
        }

        public void Atualizar(CompraGadoItem compraGadoItem)
        {
            _contexto.CompraGadoItem.Update(compraGadoItem);
        }

        public void Deletar(CompraGadoItem compraGadoItem)
        {
            _contexto.CompraGadoItem.Remove(compraGadoItem);
        }

        public async Task<int> Salvar()
        {
            return await _contexto.SaveChangesAsync();
        }

        public Task<List<CompraGadoItem>> ObterCompraGadoItens()
        {
            var response = _contexto.CompraGadoItem.ToListAsync();
            return response;
        }

        public Task<CompraGadoItem> ObterCompraGadoItemPorId(int id)
        {
            var response = _contexto.CompraGadoItem.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

    }
}
