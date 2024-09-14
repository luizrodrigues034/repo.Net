using DevFreela.Aplication.ViewModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using DevFreela.Core.Repositories;
using DevFreela.Core.DTOs;

namespace DevFreela.Aplication.Querys.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectDTO>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<ProjectDTO>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllAsync();
            
            //var projects = _dbContext.Projects;

            //var projectViewModel = _dbContext.Projects
            //.Select(p => new ProjectsViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
            //return projectViewModel;

        }
    }
}
