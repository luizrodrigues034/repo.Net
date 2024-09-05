using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implemetation
{
    public class SkillsService : ISkillsService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillsService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SkillsViewModel> GetSkills()
        {
            var skill = _dbContext.Skills.Select(x => new SkillsViewModel(x.Id, x.Description)).ToList();
            return skill;
        }
    }
}
