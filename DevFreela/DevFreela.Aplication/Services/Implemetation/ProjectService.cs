using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Implemetation
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            //o id eh gerado automaticamente
            //o id eh gerado automaticamente
            var project = new Projects(inputModel.Title, inputModel.Description, 
                inputModel.OwnedId, inputModel.FreelanceId, inputModel.TotalCost);

            _dbContext.Projects.Add(project);
            //PERSISTIR OS DADOS
            _dbContext.SaveChanges();

            //devido a BaseEntity criada no inicio ao instaciar um novo projeto, ele ja tem um id
            return project.Id;
        }

        public void CreateComment(CreateCommentInputModels inputModel)
        {
            var commentPost = new ProjectsComment(inputModel.Content, inputModel.IdUser, inputModel.IdProject);
            _dbContext.ProjectsComments.Add(commentPost);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null)
            {
                project.Cancel();
            }
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.Single(p => p.Id == id);
            project.Complete();
            _dbContext.SaveChanges();
        }

        public List<ProjectsViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectViewModel = _dbContext.Projects
                .Select(p => new ProjectsViewModel(p.Id, p.Title)).ToList();
            return projectViewModel;
            
        }
        public List<ProjectsViewModel> GetSpecific(string query)
        {
            var projectViewModel = _dbContext.Projects
                .Where(p => p.Title == query).
                Select(p => new ProjectsViewModel(p.Id ,p.Title)).ToList();
            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {


            var projects = _dbContext.Projects
                .Include(p => p.Owned)
                .Include(p => p.Freelance)
                .SingleOrDefault(p => p.Id == id);
            if (projects == null)
            {
                return null;
            }
            var projectDetails = new ProjectDetailsViewModel(projects.Id,
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

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Starting();
            _dbContext.SaveChanges();
        }

        public void Update(ProjectUpdateInputModels inputModel)
        {
            var projects = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            projects.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            _dbContext.SaveChanges();

        }
    }
}
