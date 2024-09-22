using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Authentication
{
    public interface IAuthService
    {
        public string GenerateJWTToken(string email, string role);
        public string ComputeSha256Hash(string password);
    }
}
