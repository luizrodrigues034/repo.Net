using DevFreela.Aplication.ViewModel;
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
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, List<ProjectDetailsViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetByIdProjectQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProjectDetailsViewModel>> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {

            var projects = _dbContext.Projects
                .Include(p => p.Owned)
                .Include(p => p.Freelance)
                .SingleOrDefault(p => p.Id == request.Id);
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
