﻿using DevFreela.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillsRepository
    {
        public Task<List<SkillsDTO>> GetSkillsAsync();
    }
}
