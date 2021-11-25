using Evaluacion.Core.Entities;
using Evaluacion.Core.Interfaces;
using Evaluacion.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Evaluacion.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepository;
        public CountriesController(ICountriesRepository countriesRepository) 
        {
            _countriesRepository=countriesRepository;
        }

        [HttpGet]
        [Route("Paises/{countriId}")]
        public IActionResult getConuntries(string countriId)
        {
            switch (countriId)
            {
                case "AR":
                    var countries = _countriesRepository.getCotries();
                    return Ok(countries);
                case "BR":
                    return Unauthorized();
                case "CO":
                    return Unauthorized();
                default:
                    return BadRequest();
            }
            
        }
    }
}
