namespace Fazenda.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ApplicationDbContext _contexto;

        public AnimalRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Criar(Animal animal)
        {
            _contexto.Animal.Add(animal);
        }

        public void Atualizar(Animal animal)
        {
            _contexto.Animal.Update(animal);
        }

        public void Deletar(Animal animal)
        {
            _contexto.Animal.Remove(animal);
        }

        public async Task<int> Salvar()
        {
            return await _contexto.SaveChangesAsync();
        }

        public async Task<List<Animal>> ObterAnimais()
        {
            var response = await _contexto.Animal.ToListAsync();
            return response;
        }

        public async Task<Animal> ObterAnimalPorId(int id)
        {
            var response = await _contexto.Animal.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

    }
}
