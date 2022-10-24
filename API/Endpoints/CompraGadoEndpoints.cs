namespace API.Endpoints
{
    public static class CompraGadoEndpoints
    {

        public const string POST_Route = "api/compragado/{id}";
        public const string PUT_Route = "api/compragado/{id}";
        public const string DELETE_Route = "api/compragado/{id}";
        public const string GETById_Route = "api/compragado/{id}";
        public const string GETAll_Route = "api/compragado";

        public static void Map(WebApplication app)
        {
            MapCreateCompraGado(app);
            MapUpdateCompraGado(app);
            MapDeleteCompraGado(app);
            MapGetCompraGadoById(app);
            MapGetAllComprasGado(app);
        }

        private static void MapCreateCompraGado(WebApplication app)
        {
            app.MapPost(POST_Route, async (CompraGadoRepository compragadoRepository, CompraGado compraGado) =>
            {
                try
                {
                    compragadoRepository.Criar(compraGado);
                    await compragadoRepository.Salvar();
                    return Results.Created($"{GETAll_Route}/{compraGado.Id}", compraGado);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).Produces<CompraGado>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);
        }

        private static void MapUpdateCompraGado(WebApplication app)
        {
            app.MapPut(PUT_Route, async (CompraGadoRepository compragadoRepository, CompraGado compraGado) =>
            {
                try
                {
                    compragadoRepository.Atualizar(compraGado);
                    await compragadoRepository.Salvar();
                    return Results.Ok(compraGado);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapDeleteCompraGado(WebApplication app)
        {
            app.MapDelete(DELETE_Route, async (CompraGadoRepository compragadoRepository, int id) =>
            {
                try
                {
                    CompraGado compraGado = await compragadoRepository.ObterCompraGadoPorId(id);

                    if (compraGado == null) return Results.UnprocessableEntity();

                    compragadoRepository.Deletar(compraGado);
                    await compragadoRepository.Salvar();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapGetCompraGadoById(WebApplication app)
        {
            app.MapGet(GETById_Route, async (CompraGadoRepository compragadoRepository, int id) =>
            {
                try
                {
                    CompraGado compraGado = await compragadoRepository.ObterCompraGadoPorId(id);
                    if (compraGado == null) return Results.NoContent();
                    return Results.Ok(compraGado);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

        private static void MapGetAllComprasGado(WebApplication app)
        {
            app.MapGet(GETAll_Route, async (CompraGadoRepository compragadoRepository) =>
            {
                try
                {
                    List<CompraGado> comprasGado = await compragadoRepository.ObterCompraGado();
                    if (comprasGado == null) return Results.NoContent();
                    return Results.Ok(comprasGado);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

    }
}
