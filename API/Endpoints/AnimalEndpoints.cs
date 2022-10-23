using Fazenda.Domain.Entities;

namespace API.Endpoints
{
    public static partial class AnimalEndpoints
    {
        //app.MapGet("products/{id}", );
        //app.MapGet("products", );
        //app.MapPost("products", );

        public static void Map(WebApplication app)
        {
            MapGetAnimalById(app);
            //MapGetAllAnimals(app);
        }

        private static void MapGetAnimalById(WebApplication app) 
        {
            app.MapGet("/animal/{id}", async (AnimalRepository animalRepository, int id) =>
            {
                Animal animal = await animalRepository.ObterAnimalPorId(id);
                if (animal != null) Results.Ok(animal);
                else Results.NotFound();
            });
        }

        private static void MapGetAllAnimals(WebApplication app)
        {

        }
    }
}
