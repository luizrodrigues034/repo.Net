using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;
        public SkillsRepository(IConfiguration configuration, DevFreelaDbContext dbContext)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        
        public async Task<List<SkillsDTO>> GetSkillsAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Description FROM Skills";

                //Query -> Dapper, metodo de consulta, podemos utilizalo para alterar os dados tambem
                var skills = await sqlConnection.QueryAsync<SkillsDTO>(script);
                return skills.ToList();
            }
        }
        public async Task CreateUser(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
