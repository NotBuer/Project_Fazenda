namespace Pecuaria.Services
{
    public static class Services
    {
        public const string API_URL = "https://localhost:7008/";

        public const string ANIMAL_POST_Route = "api/animal/{id}";
        public const string ANIMAL_PUT_Route = "api/animal/{id}";
        public const string ANIMAL_DELETE_Route = "api/animal/{id}";
        public const string ANIMAL_GETById_Route = "api/animal/{id}";
        public const string ANIMAL_GETAll_Route = "api/animal";

        public const string COMPRAGADO_POST_Route = "api/compragado/{id}";
        public const string COMPRAGADO_PUT_Route = "api/compragado/{id}";
        public const string COMPRAGADO_DELETE_Route = "api/compragado/{id}";
        public const string COMPRAGADO_GETById_Route = "api/compragado/{id}";
        public const string COMPRAGADO_GETAll_Route = "api/compragado";

        public const string PECUARISTA_POST_Route = "api/pecuarista/{id}";
        public const string PECUARISTA_PUT_Route = "api/pecuarista/{id}";
        public const string PECUARISTA_DELETE_Route = "api/pecuarista/{id}";
        public const string PECUARISTA_GETById_Route = "api/pecuarista/{id}";
        public const string PECUARISTA_GETAll_Route = "api/pecuarista";
        public const string PECUARISTA_GETByName_Route = "api/pecuarista/name/";

        public const string COMPRAGADOITEM_POST_Route = "api/compragadoitem/{id}";
        public const string COMPRAGADOITEM_PUT_Route = "api/compragadoitem/{id}";
        public const string COMPRAGADOITEM_DELETE_Route = "api/compragadoitem/{id}";
        public const string COMPRAGADOITEM_GETById_Route = "api/compragadoitem/{id}";
        public const string COMPRAGADOITEM_GETAll_Route = "api/compragadoitem";
    }
}
