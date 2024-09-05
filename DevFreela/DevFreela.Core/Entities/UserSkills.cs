using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserSkills : BaseEntity
    {
        public UserSkills(int idUser, int skillsId)
        {
            IdUser = idUser;
            SkillsId = skillsId;
        }
        public int IdUser { get; private set; }
        public int SkillsId { get; private set; }
        
    
    }
}
