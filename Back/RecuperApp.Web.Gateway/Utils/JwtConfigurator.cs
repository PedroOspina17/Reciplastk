using Microsoft.IdentityModel.Tokens;
using RecuperApp.Domain.Models.EntityModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecuperApp.Web.Gateway.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Employee userInfo, IConfiguration configuration)
        {
            string SecretKey = configuration["Jwt:SecretKey"];
            string Issuer = configuration["Jwt:Issuer"];
            string Audience = configuration["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credencials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("idUsuario", userInfo.EmployeeId.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credencials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach (var claim in claims)
                {
                    if (claim.Type == "idUsuario")
                    {
                        return int.Parse(claim.Value);
                    }
                }
            }

            return 0;
        }
    }
}
