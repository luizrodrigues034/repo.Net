using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DevFreela.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(IConfiguration configuration, DevFreelaDbContext dbContext)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
            _dbContext = dbContext;
        }
        public async Task<List<ProjectDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "Select Id, Title FROM Projects";
                var projectsList = await sqlConnection.QueryAsync<ProjectDTO>(script);

                return projectsList.ToList();

            }
        }
        public async Task<Projects> GetDetailsById(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Owned)
                .Include(p => p.Freelance)
                .SingleOrDefaultAsync(p => p.Id == id);
             
        }

        public async Task PosteCommentAsync(ProjectsComment comment)
        {
            await _dbContext.ProjectsComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
        }
    }


}
