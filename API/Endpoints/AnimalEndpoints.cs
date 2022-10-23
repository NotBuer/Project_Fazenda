using Fazenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static partial class AnimalEndpoints
    {

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
            app.MapPost("/animal/{id}", async (AnimalRepository animalRepository, Animal animal) => 
            {
                try
                {
                    animalRepository.Criar(animal);
                    await animalRepository.Salvar();
                    return Results.Created($"/animal/{animal.IdAnimal}", animal);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapUpdateAnimal(WebApplication app)
        {
            app.MapPut("/animal/{id}", async (AnimalRepository animalRepository, Animal animal) =>
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
            app.MapDelete("/delete/{id}", async (AnimalRepository animalRepository, int id) =>
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
            app.MapGet("/animal/{id}", async (AnimalRepository animalRepository, int id) =>
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
            app.MapGet("/animal", async (AnimalRepository animalRepository) =>
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
