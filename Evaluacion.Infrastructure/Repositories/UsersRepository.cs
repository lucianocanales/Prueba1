using Evaluacion.Core.Entities;
using Evaluacion.Core.Interfaces;
using Evaluacion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure.Repositories
{
    public class UsersRepository:IUsersRepository
    {

        private readonly EvaluacionEj1Context _context;
        public UsersRepository(EvaluacionEj1Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<Users> GetUsers(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task IncertUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Users user)
        {
            var currentUser = await GetUsers(user.Id);
            currentUser.Nombre = user.Nombre;
            currentUser.Apellido = user.Apellido;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentUser = await GetUsers(id);
            _context.Users.Remove(currentUser);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
