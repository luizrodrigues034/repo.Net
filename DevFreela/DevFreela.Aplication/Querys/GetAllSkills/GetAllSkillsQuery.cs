﻿using DevFreela.Aplication.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Querys.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillsViewModel>>
    {

    }
}
