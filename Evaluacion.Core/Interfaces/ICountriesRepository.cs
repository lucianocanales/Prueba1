
using Evaluacion.Core.Entities;
using System.Threading.Tasks;

namespace Evaluacion.Core.Interfaces
{
    public interface ICountriesRepository
    {
        public Countries getCotries();
        public Task<string> httpCliente(string URL);
    }
}
