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
using Azure.Core;

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

        public async Task CreateProject(Projects project)
        {
            await _dbContext.Projects.AddAsync(project);
            //PERSISTIR OS DADOS
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task StartProjectAsync(Projects project)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "UPDATE Project SET Staus = @status, StartedAt = @startedAt WHERE Id = @id";
                await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedat = project.StartedAt, project.Id});
            }
        }
    }   


}
