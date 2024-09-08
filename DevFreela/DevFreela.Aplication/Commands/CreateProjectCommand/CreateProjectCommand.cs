using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DevFreela.Aplication.Commands.CreateProjectCommand
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { set; get; }
        public int OwnedId { set; get; }
        public int FreelanceId { get; set; }
    }
}
