namespace API.Endpoints
{
    public static class AnimalEndpoints
    {

        public const string POST_Route = "api/animal/{id}";
        public const string PUT_Route = "api/animal/{id}";
        public const string DELETE_Route = "api/animal/{id}";
        public const string GETById_Route = "api/animal/{id}";
        public const string GETAll_Route = "api/animal";

        public static void Map(WebApplication app)
        {
            MapCreateAnimal(app);
            MapUpdateAnimal(app);
            MapDeleteAnimal(app);
            MapGetAnimalById(app);
            MapGetAllAnimals(app);
        }

        private static void MapCreateAnimal(WebApplication app)
        {
            app.MapPost(POST_Route, async (AnimalRepository animalRepository, Animal animal) => 
            {
                try
                {
                    animalRepository.Criar(animal);
                    await animalRepository.Salvar();
                    return Results.Created($"{GETAll_Route}/{animal.Id}", animal);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapUpdateAnimal(WebApplication app)
        {
            app.MapPut(PUT_Route, async (AnimalRepository animalRepository, Animal animal) =>
            {
                try
                {
                    animalRepository.Atualizar(animal);
                    await animalRepository.Salvar();
                    return Results.Ok(animal);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapDeleteAnimal(WebApplication app)
        {
            app.MapDelete(DELETE_Route, async (AnimalRepository animalRepository, int id) =>
            {
                try
                {
                    Animal animal = await animalRepository.ObterAnimalPorId(id);

                    if (animal == null) return Results.UnprocessableEntity();

                    animalRepository.Deletar(animal);
                    await animalRepository.Salvar();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapGetAnimalById(WebApplication app) 
        {
            app.MapGet(GETById_Route, async (AnimalRepository animalRepository, int id) =>
            {
                try
                {
                    Animal animal = await animalRepository.ObterAnimalPorId(id);
                    if (animal == null) return Results.NoContent();
                    return Results.Ok(animal);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

        private static void MapGetAllAnimals(WebApplication app)
        {
            app.MapGet(GETAll_Route, async (AnimalRepository animalRepository) =>
            {
                try
                {
                    List<Animal> animals = await animalRepository.ObterAnimais();
                    if (animals == null) return Results.NoContent();
                    return Results.Ok(animals);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }
    }
}
