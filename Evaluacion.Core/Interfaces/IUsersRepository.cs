using Evaluacion.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluacion.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUsers(int id);
        Task IncertUser(Users user);
        Task<bool> UpdatePost(Users user);
        Task<bool> DeletePost(int id);
    }
}
