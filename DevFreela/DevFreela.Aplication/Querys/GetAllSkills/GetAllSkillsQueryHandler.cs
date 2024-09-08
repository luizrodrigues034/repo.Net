using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Aplication.Querys.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillsViewModel>>
        {
        private readonly string _connectionString;
        public GetAllSkillsQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillsViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Description FROM Skills";

                //Query -> Dapper, metodo de consulta, podemos utilizalo para alterar os dados tambem
                var skills = await sqlConnection.QueryAsync<SkillsViewModel>(script);
                return skills.ToList();
            }

        }
    }
}
