using Evaluacion.Core.Entities;
using Evaluacion.Core.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure.Repositories
{
    public class CountriesRepository: ICountriesRepository
    {

        public  Countries getCotries()
        {
            string URL = "https://api.mercadolibre.com/classified_locations/countries/AR";
            Task<string> request = this.httpCliente(URL);
            string json = request.Result;
            Countries resul = JsonConvert.DeserializeObject<Countries>(json);
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
