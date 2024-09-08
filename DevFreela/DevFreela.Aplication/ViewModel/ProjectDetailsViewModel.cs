using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id,
            string title,
            string description,
            int ownedId,
            decimal totalCost,
            DateTime createdAt,
            string ownedFullName,
            string freelanceFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            OwnedId = ownedId;
            TotalCost = totalCost;
            CreatedAt = createdAt;
            OwnedFullName = ownedFullName;
            FreelanceFullName = freelanceFullName;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnedId { get; set; }
        public decimal TotalCost{ get; set; }
        public DateTime CreatedAt { get; set; }
        public string OwnedFullName { get; private set; }
        public string FreelanceFullName { get; private set; }
    }
}
