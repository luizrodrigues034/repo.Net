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

namespace DevFreela.Aplication.Querys.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectsViewModel>>
    {
        private readonly string _connectionString;
        public GetAllProjectsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<ProjectsViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "Select Id, Title, CreatedAt FROM Projects";
                var projectsList = await sqlConnection.QueryAsync<ProjectsViewModel>(script);

                return projectsList.ToList();

            }
            //var projects = _dbContext.Projects;

            //var projectViewModel = _dbContext.Projects
            //.Select(p => new ProjectsViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
            //return projectViewModel;

        }
    }
}
