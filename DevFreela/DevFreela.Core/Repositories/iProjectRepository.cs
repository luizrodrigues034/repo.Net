using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<ProjectDTO>> GetAllAsync();
        Task<Projects> GetDetailsById(int id);
        Task PosteCommentAsync(ProjectsComment comment);
        Task CreateProject(Projects project);
        Task SaveChangesAsync();
        Task StartProjectAsync(Projects project);

    }
}
