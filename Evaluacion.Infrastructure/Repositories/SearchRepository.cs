using Evaluacion.Core.Entities.Busqueda;
using Evaluacion.Core.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure.Repositories
{
    public class SearchRepository: ISearchRepository
    {
        public Search getSearch(string q)
        {
            string URL = "https://api.mercadolibre.com/sites/MLA/search?q="+q;
            Task<string> request = this.httpCliente(URL);
            string json = request.Result;
            Search resul = JsonConvert.DeserializeObject<Search>(json);
            return resul;

        }
        public async Task<string> httpCliente(string URL)
        {
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync(URL);
            return await responce.Content.ReadAsStringAsync();
        }

    }
}
