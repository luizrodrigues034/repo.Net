using DevFreela.Aplication.InputModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.CreateProjectCommand
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
         
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            //o id eh gerado automaticamente
            //o id eh gerado automaticamente
            var project = new Projects(request.Title, request.Description,
                request.OwnedId, request.FreelanceId, request.TotalCost);
            await _projectRepository.CreateProject(project);
            //devido a BaseEntity criada no inicio ao instaciar um novo projeto, ele ja tem um id
            return project.Id;
            
        }
    }
}
