
namespace DevFreela.Core.Entities
{
    public class ProjectsComment : BaseEntity
    {
        public ProjectsComment(string content, int idUser, int idProject)
        {
            Content = content;
            CreatedAt = DateTime.Now;
            IdUser = idUser;
            IdProject = idProject;
        }
        public Projects Projects { get; set; }
        public Users Users { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}