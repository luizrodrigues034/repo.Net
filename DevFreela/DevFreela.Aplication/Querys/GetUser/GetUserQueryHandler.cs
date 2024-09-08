﻿using DevFreela.Aplication.ViewModel;
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
        private readonly DevFreelaDbContext _dbContext;
        public GetUserQueryHandler(DevFreelaDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userViwer =  _dbContext.Users.SingleOrDefault(x => x.Id == request.Id);
            if (userViwer == null) { return null; }
            return new UserViewModel(userViwer.FullName, userViwer.Email);
        }
    }
}
