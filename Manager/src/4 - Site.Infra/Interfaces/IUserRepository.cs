using System.Threading.Tasks;
using Site.Domain.Entities;
using System.Collections.Generic;

namespace Site.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);

    }
}