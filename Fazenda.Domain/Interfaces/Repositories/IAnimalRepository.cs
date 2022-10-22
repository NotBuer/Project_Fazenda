namespace Fazenda.Domain.Interfaces.Repositories
{
    public interface IAnimalRepository
    {
        void Criar(Animal animal);
        void Atualizar(Animal animal);
        void Deletar(Animal animal);

        Task<int> Salvar();

        Task<List<Animal>> ObterAnimais();
        Task<Animal> ObterAnimalPorId(int id);
    }
}
