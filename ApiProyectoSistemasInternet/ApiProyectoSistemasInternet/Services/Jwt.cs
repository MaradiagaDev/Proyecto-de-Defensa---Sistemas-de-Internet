using ApiProyectoSistemasInternet.Repositories;
using System.Security.Claims;

namespace ApiProyectoSistemasInternet.Services
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        private static UserRepository _repository = new UserRepository();

        public static bool ValidateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return false;
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;

                return _repository.GetObjectById(Convert.ToInt32(id)).isExitoso != false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
