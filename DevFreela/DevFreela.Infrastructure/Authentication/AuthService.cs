using DevFreela.Core.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())//Criacao de uma instaca SHA256, funcao de hash de criptografia, O 256.Create incializa o objeto
                //sha256Hash sera utilizado para utilizar o metodos disponiveis dentro do hash
            {
                //Pega a astring e tranforma EM ARRAY DE BYTES
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                
                //Instaciamos um StringBuilder por ser um metodo mais eficiente para memoria
                StringBuilder builder = new StringBuilder();

                //no for percorremos o array de bytes
                for (int i = 0; i < bytes.Length; i++)
                {
                    //Percorremos cada elemento do array transformamos em hexadecima
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }

        public string GenerateJWTToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("username", email),
                new Claim(ClaimTypes.Role, role)

            };
            var token = new JwtSecurityToken(
                issuer : issuer,
                audience: audience,
                expires : DateTime.Now.AddHours(8),
                signingCredentials : credentials, 
                claims: claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
