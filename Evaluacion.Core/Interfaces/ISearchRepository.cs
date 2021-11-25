using Evaluacion.Core.Entities.Busqueda;
using System.Threading.Tasks;

namespace Evaluacion.Core.Interfaces
{
    public interface ISearchRepository
    {
        public Search getSearch(string q);
        public Task<string> httpCliente(string URL);
    }
}
