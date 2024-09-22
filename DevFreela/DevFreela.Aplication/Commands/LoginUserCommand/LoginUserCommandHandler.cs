using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Authentication;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViwer>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViwer> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string encripPass = _authService.ComputeSha256Hash(request.Password); 
            var userValidation = await _userRepository.Login(request.Email, encripPass);
            if(userValidation == null) {return null;}
            var token = _authService.GenerateJWTToken(userValidation.Email, userValidation.Role);
            return new LoginUserViwer(request.Email, token);
            
        }
    }
}
