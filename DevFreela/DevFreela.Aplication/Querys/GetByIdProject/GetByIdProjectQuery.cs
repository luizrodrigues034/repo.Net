using DevFreela.Aplication.Services.Implemetation;
using DevFreela.Aplication.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Querys.GetByIdProject
{
    public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
