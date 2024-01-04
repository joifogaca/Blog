using Blog.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); //objeto que gera o token

            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // pega a chave

            var tokenDescriptor = new SecurityTokenDescriptor 
            { 
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, "joifogaca"), //User.Identity.Name
                    new Claim(ClaimTypes.Role, "admin"), //User.IsInRole
                    new Claim(ClaimTypes.Role, "user")
                //new Claim("fruta", "banana") EXEMPLO
                }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)

            }; // especificação do Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); //converte em string
        }

    }
}
