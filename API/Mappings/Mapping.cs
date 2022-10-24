using API.Endpoints;

namespace API.Mappings
{
    public static class Mapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            AnimalEndpoints.Map(app);
            CompraGadoEndpoints.Map(app);
            CompraGadoItemEndpoints.Map(app);
            PecuaristaEndpoints.Map(app);
        }
    }
}
