using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class UserViwerModel
    {
        public UserViwerModel(int id, string fullName, string email, DateTime birthDay)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDay = birthDay;
        }

        public int Id { get;  set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDay { get;  set; }
    }
}
