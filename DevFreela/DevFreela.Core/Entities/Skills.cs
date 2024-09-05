using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    //Herdamos a BaseEntity por se tratar da entidade base entao herdamos valores que vao ser padrao em todas as entidades
    public class Skills : BaseEntity
    {
        public Skills(int id,string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
           

            
        }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
