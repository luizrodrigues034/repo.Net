using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IUserService
    {
        Users GetUser(int id);
        int AddUser(UserInputModel user);


    }
}
