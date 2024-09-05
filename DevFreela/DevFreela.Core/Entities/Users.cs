using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Users : BaseEntity
    {
        public Users(string fullName, string email, DateTime birthDay ) 
        {
            FullName = fullName;
            Email = email;
            BirthDay = birthDay;

            Active = true;
            CreatedAt = DateTime.Now;

            Skills = new List<UserSkills>();
            OwnedProjects = new List<Projects>();
            FreelanceProjects = new List<Projects>();

        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDay { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkills> Skills { get; private set; }
        public int SkillId { get; private set; }
        public List<Projects> OwnedProjects { get; private set; }
        public List<Projects> FreelanceProjects {  get; private set; }
        public List<ProjectsComment> Comments { get; private set; }
        public bool Active { get; private set; }







        //atributos Name, email, aniversario, Data de criacao da conta, lista de userskills (aq devemos criar a user skills(entidade) com idUser, e idSkils)
        //lista de projetos(classe) para contratantes e outra para freelancer, e um bool Active
        //Na entidade projetos devemos criar alguns ateributos
        //Titulo, Descricao,Id do cliente, Id do freelance, custo toal, data de criacao do projeto, quando foi incializado
        //status, definido por uma entidade chamada ProjectStatusEnum
        //Comentatios, por uma entidade chamada ProjectComment

        //No ProjectStatus enum, definimos Created, emProgresso, Suspenso, Cancelado, Finalizado com valores inteiros
        //No ProjectComment conteudo, idProject, IdUser, Data do comentario
        
    }
}
