using Newtonsoft.Json;
using Pecuaria.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pecuaria.Services
{
    public static class DataAccess
    {

        public static async Task<Pecuarista> ObterPecuaristaPorNome(string nome)
        {
            string URI_GET = Services.API_URL + Services.PECUARISTA_GETByName_Route + "{" + nome + "}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_GET))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Pecuarista pecuarista = JsonConvert.DeserializeObject<Pecuarista>(json);
                        return pecuarista;
                    }
                }
            }
            return null;
        }

    }
}
