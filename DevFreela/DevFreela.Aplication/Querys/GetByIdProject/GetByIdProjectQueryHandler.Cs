using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Querys.GetByIdProject
{
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository ;
        public GetByIdProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {

            var projects = await _projectRepository.GetDetailsById(request.Id);
            if (projects == null)
            {
                return null;
            }
            var projectDetails = new ProjectDetailsViewModel(
                projects.Id,
                projects.Title,
                projects.Description,
                projects.OwnedId,
                projects.TotalCost,
                projects.CreatedAt,
                projects.Owned.FullName,
                projects.Freelance.FullName
                );
            return projectDetails;
        }
    }
}
