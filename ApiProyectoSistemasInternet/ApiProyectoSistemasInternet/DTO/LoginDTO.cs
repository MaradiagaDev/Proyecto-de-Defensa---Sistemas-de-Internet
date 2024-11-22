using ApiProyectoSistemasInternet.Repositories;
using ApiProyectoSistemasInternet.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiProyectoSistemasInternet.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private UserRepository repository = new UserRepository();
        public String AuthenticateAsync()
        {
            try
            {
                var userID = repository.Login(Username, Password).resultado.IdUsuario;

                var jwt = AppSettings.Configuration.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", userID.ToString())
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddDays(2),
                    signingCredentials: signingCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
