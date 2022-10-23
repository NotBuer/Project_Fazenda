using API.Endpoints;

namespace API.Mappings
{
    public static class Mapping
    {
        public static void MapEndpoints(this WebApplication app)
        {
            // TODO: Map all entities endpoints.

            AnimalEndpoints.Map(app);
        }
    }
}
