using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            
            FullName = fullName;
            Email = email;
            
        }

       
        public string FullName { get;  set; }
        public string Email { get;  set; }
        
    }
}
