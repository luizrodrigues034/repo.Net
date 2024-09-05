using DevFreela.Aplication.InputModels;
using DevFreela.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectsViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id_);
        int Create(NewProjectInputModel inputModel);
        void Update(ProjectUpdateInputModels inputModel);
        void CreateComment(CreateCommentInputModels inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
        List<ProjectsViewModel> GetSpecific(string query);


    }
}
