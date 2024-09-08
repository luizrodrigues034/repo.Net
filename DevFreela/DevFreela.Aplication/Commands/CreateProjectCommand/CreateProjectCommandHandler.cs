using DevFreela.Aplication.InputModels;
using DevFreela.Core.Entities;
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
        private readonly DevFreelaDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
         
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            //o id eh gerado automaticamente
            //o id eh gerado automaticamente
            var project = new Projects(request.Title, request.Description,
                request.OwnedId, request.FreelanceId, request.TotalCost);

            await _dbContext.Projects.AddAsync(project);
            //PERSISTIR OS DADOS
            await _dbContext.SaveChangesAsync();

            //devido a BaseEntity criada no inicio ao instaciar um novo projeto, ele ja tem um id
            return project.Id;
            
        }
    }
}
