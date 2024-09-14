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
using DevFreela.Core.Repositories;
using DevFreela.Core.DTOs;

namespace DevFreela.Aplication.Querys.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillsDTO>>
        {
        private readonly ISkillsRepository _skillsRepository;
        public GetAllSkillsQueryHandler(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;
        }

        public async Task<List<SkillsDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _skillsRepository.GetSkillsAsync();

        }
    }
}
