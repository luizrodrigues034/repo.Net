using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Users> GetUserAsync(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }
        public async Task CreateUser(Users user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
