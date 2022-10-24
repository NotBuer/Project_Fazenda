namespace API.Endpoints
{
    public static class CompraGadoItemEndpoints
    {
        public const string POST_Route = "api/compragadoitem/{id}";
        public const string PUT_Route = "api/compragadoitem/{id}";
        public const string DELETE_Route = "api/compragadoitem/{id}";
        public const string GETById_Route = "api/compragadoitem/{id}";
        public const string GETAll_Route = "api/compragadoitem";

        public static void Map(WebApplication app)
        {
            MapCreateCompraGadoItem(app);
            MapUpdateCompraGadoItem(app);
            MapDeleteCompraGadoItem(app);
            MapGetCompraGadoItemById(app);
            MapGetAllCompraGadoItems(app);
        }

        private static void MapCreateCompraGadoItem(WebApplication app)
        {
            app.MapPost(POST_Route, async (CompraGadoItemRepository compragadoitemRepository, CompraGadoItem compragadoitem) =>
            {
                try
                {
                    compragadoitemRepository.Criar(compragadoitem);
                    await compragadoitemRepository.Salvar();
                    return Results.Created($"{GETAll_Route}/{compragadoitem.Id}", compragadoitem);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapUpdateCompraGadoItem(WebApplication app)
        {
            app.MapPut(PUT_Route, async (CompraGadoItemRepository compragadoitemRepository, CompraGadoItem compragadoitem) =>
            {
                try
                {
                    compragadoitemRepository.Atualizar(compragadoitem);
                    await compragadoitemRepository.Salvar();
                    return Results.Ok(compragadoitem);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapDeleteCompraGadoItem(WebApplication app)
        {
            app.MapDelete(DELETE_Route, async (CompraGadoItemRepository compragadoitemRepository, int id) =>
            {
                try
                {
                    CompraGadoItem compragadoitem = await compragadoitemRepository.ObterCompraGadoItemPorId(id);

                    if (compragadoitem == null) return Results.UnprocessableEntity();

                    compragadoitemRepository.Deletar(compragadoitem);
                    await compragadoitemRepository.Salvar();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static void MapGetCompraGadoItemById(WebApplication app)
        {
            app.MapGet(GETById_Route, async (CompraGadoItemRepository compragadoitemRepository, int id) =>
            {
                try
                {
                    CompraGadoItem compragadoitem = await compragadoitemRepository.ObterCompraGadoItemPorId(id);
                    if (compragadoitem == null) return Results.NoContent();
                    return Results.Ok(compragadoitem);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }

        private static void MapGetAllCompraGadoItems(WebApplication app)
        {
            app.MapGet(GETAll_Route, async (CompraGadoItemRepository compragadoitemRepository) =>
            {
                try
                {
                    List<CompraGadoItem> compragadoitens = await compragadoitemRepository.ObterCompraGadoItens();
                    if (compragadoitens == null) return Results.NoContent();
                    return Results.Ok(compragadoitens);

                }
                catch (Exception ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });
        }
    }
}
