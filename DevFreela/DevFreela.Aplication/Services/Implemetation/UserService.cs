using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implemetation
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddUser(UserInputModel inputModel)
        {   

             var newUser = new Users(inputModel.FullName, inputModel.Email, inputModel.BirthDay);
            _dbContext.Users.Add(newUser);
            return newUser.Id;
            _dbContext.SaveChanges();

        }

        public Users GetUser(int id)
        {
            var userViwer = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            return userViwer;
        }
    }
}
