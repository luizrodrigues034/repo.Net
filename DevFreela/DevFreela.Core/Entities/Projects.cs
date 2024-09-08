using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class Projects : BaseEntity
    {
        public Projects(string title, string description, int ownedId, int freelanceId, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            OwnedId = ownedId;
            FreelanceId = freelanceId;
            CreatedAt = DateTime.Now;
            Status = ProjectsStatusEnum.Created;
            Comments = new List<ProjectsComment>();
        }

        public string Title {  get; private set; }
        public string Description { get; private set; }

        public Users Owned { get; private set; }
        public Users Freelance { get; private set; }
        public int OwnedId { get; private set; }
        public int FreelanceId { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishidAt { get; set; }
        public ProjectsStatusEnum Status {  get; private set; }
        public List<ProjectsComment> Comments { get; private set; }
      

        public void Cancel()
        {
            if(Status == ProjectsStatusEnum.InProgress || Status == ProjectsStatusEnum.Created)
            {
                Status = ProjectsStatusEnum.Cancelled;
            }
        }
        public void Complete()
        {
            if(Status == ProjectsStatusEnum.InProgress) 
            {
                Status = ProjectsStatusEnum.Finished;
                DateTime finishAt = DateTime.Now;
            }
        }
        public void Starting()
        {
            DateTime startedAt;
            if (Status == ProjectsStatusEnum.Created)
            {
                Status = ProjectsStatusEnum.InProgress;
                startedAt = DateTime.Now;
            }
            
        }
        public void Update( string title, string description,decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
