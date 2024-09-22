using DevFreela.Aplication.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<LoginUserViwer>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
