namespace API.Endpoints
{
    public static class PecuaristaEndpoints
    {

        public const string POST_Route = "api/pecuarista/{id}";
        public const string PUT_Route = "api/pecuarista/{id}";
        public const string DELETE_Route = "api/pecuarista/{id}";
        public const string GETById_Route = "api/pecuarista/{id}";
        public const string GETAll_Route = "api/pecuarista";
        public const string GETByName_Route = "api/pecuarista/name/{name}";

        public static void Map(WebApplication app)
        {
            MapCreatePecuarista(app);
            MapUpdatePecuarista(app);
            MapDeletePecuarista(app);
            MapGetPecuaristaById(app);
            MapGetAllPecuaristas(app);
            MapGetPecuaristaByName(app);
        }

        private static void MapCreatePecuarista(WebApplication app)
        {
            app.MapPost(POST_Route, async (PecuaristaRepository pecuaristaRepository, Pecuarista pecuarista) =>
            {
                try
                {
                    pecuaristaRepository.Criar(pecuarista);
                    await pecuaristaRepository.Salvar();
                    return Results.Created($"{GETAll_Route}/{pecuarista.Id}", pecuarista);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapUpdatePecuarista(WebApplication app)
        {
            app.MapPut(PUT_Route, async (PecuaristaRepository pecuaristaRepository, Pecuarista pecuarista) =>
            {
                try
                {
                    pecuaristaRepository.Atualizar(pecuarista);
                    await pecuaristaRepository.Salvar();
                    return Results.Ok(pecuarista);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapDeletePecuarista(WebApplication app)
        {
            app.MapDelete(DELETE_Route, async (PecuaristaRepository pecuaristaRepository, int id) =>
            {
                try
                {
                    Pecuarista pecuarista = await pecuaristaRepository.ObterPecuaristaPorId(id);

                    if (pecuarista == null) return Results.UnprocessableEntity();

                    pecuaristaRepository.Deletar(pecuarista);
                    await pecuaristaRepository.Salvar();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapGetPecuaristaById(WebApplication app)
        {
            app.MapGet(GETById_Route, async (PecuaristaRepository pecuaristaRepository, int id) =>
            {
                try
                {
                    Pecuarista pecuarista = await pecuaristaRepository.ObterPecuaristaPorId(id);
                    if (pecuarista == null) return Results.NoContent();
                    return Results.Ok(pecuarista);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

        private static void MapGetAllPecuaristas(WebApplication app)
        {
            app.MapGet(GETAll_Route, async (PecuaristaRepository pecuaristaRepository) =>
            {
                try
                {
                    List<Pecuarista> pecuaristas = await pecuaristaRepository.ObterPecuaristas();
                    if (pecuaristas == null) return Results.NoContent();
                    return Results.Ok(pecuaristas);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

        private static void MapGetPecuaristaByName(WebApplication app)
        {
            app.MapGet(GETByName_Route, async (PecuaristaRepository pecuaristaRepository, [FromQuery] string name) =>
            {
                try
                {
                    Pecuarista pecuarista = await pecuaristaRepository.ObterPecuaristaPorNome(name);
                    if (pecuarista == null) return Results.NoContent();
                    return Results.Ok(pecuarista);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

    }
}
