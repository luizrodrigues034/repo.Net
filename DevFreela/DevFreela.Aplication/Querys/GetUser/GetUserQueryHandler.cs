using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Querys.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository ;
        public GetUserQueryHandler(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userViwer =  await _userRepository.GetUserAsync(request.Id);
            if (userViwer == null) { return null; }
            return new UserViewModel(userViwer.FullName, userViwer.Email);
        }
    }
}
