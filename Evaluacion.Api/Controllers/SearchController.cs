using Evaluacion.Core.Interfaces;
using Evaluacion.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _SearchRepository;
        public SearchController(ISearchRepository SearchRepository)
        {
            _SearchRepository=SearchRepository;
        }
        [HttpGet]
        [Route("Busqueda/{q}")]
        public IActionResult getSearch(string q)
        {
            var search = _SearchRepository.getSearch(q);
            return Ok(search);
        }
    }
}
