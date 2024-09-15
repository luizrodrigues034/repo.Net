using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Commands.UpdateProjectCommand
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommandHandler(IProjectRepository projectRepsitoty)
        {
            _projectRepository = projectRepsitoty;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetDetailsById(request.Id);
            projects.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
