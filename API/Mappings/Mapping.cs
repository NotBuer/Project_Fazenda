using API.Endpoints;

namespace API.Mappings
{
    public static class Mapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            AnimalEndpoints.Map(app);
            // TODO: Map CompraGado
            // TODO: Map CompraGadoItem
            // TODO: Map Pecuarista
        }
    }
}
