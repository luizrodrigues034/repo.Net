using Dapper;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.StartProjectCommand
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        
        public StartProjectCommandHandler(IProjectRepository projectRepository, IConfiguration configuration)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetDetailsById(request.Id);
            projects.Starting();
            await _projectRepository.StartProjectAsync(projects);
            return Unit.Value;
        }
    }
}
