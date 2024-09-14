using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.DTOs;
using MediatR;

namespace DevFreela.Aplication.Querys.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectDTO>>
    {
    }
}
