using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class ProjectsViewModel
    {
        public ProjectsViewModel(int id, string title)
        {
            Id = id;
            Title = title;
            
        }
        
        public int Id { get; set; }
        public string Title { get; set; }

    }
}
