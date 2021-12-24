using Site.Domain.Entities;
using Site.Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Site.Infra.Context;

namespace Site.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                .Where(
                                    x => x.Email.ToLower() == email.ToLower()
                                )
                                .AsNoTracking()
                                .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUsers = await _context.Users
                                .Where(
                                    x => x.Email.ToLower().Contains(email.ToLower())
                                )
                                .AsNoTracking()
                                .ToListAsync();

            return allUsers;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUsers = await _context.Users
                                .Where(
                                    x => x.Name.ToLower().Contains(name.ToLower())
                                )
                                .AsNoTracking()
                                .ToListAsync();

            return allUsers;
        }
    }
}