using Evaluacion.Core.Entities;
using Evaluacion.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evaluacion.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersRepository _UsersRepository;

        public UsersController(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }
        // GET: api/usuarios
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _UsersRepository.GetUsers();
            return Ok(users);
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _UsersRepository.GetUsers(id);
            return Ok(user);
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post(Users user)
        {
            await _UsersRepository.IncertUser(user);
            return Ok(user);
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Users user)
        {
            var ret = await _UsersRepository.UpdatePost(user);
            return Ok(ret);
        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ret = await _UsersRepository.DeletePost(id);
            return Ok(ret);
        }
    }
}
