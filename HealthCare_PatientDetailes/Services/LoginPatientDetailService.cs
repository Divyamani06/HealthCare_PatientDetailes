using HealthCare_PatientDetailes.Authentication;
using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCare_PatientDetailes.Services
{
    public class LoginPatientDetailService:ILoginPatientDetailService
    {
        private readonly JwtToken _jwtToken;

        public LoginPatientDetailService(IOptions<JwtToken> options)
        {
            _jwtToken = options.Value;
        }

        public string LoginPatientDetails(LoginModel loginModel)
        {
            if (loginModel.Email == "testmail@gmail.com" && loginModel.Password == "testpassword")
            {
                var token = GenerateToken(loginModel);
                return token;
            }
            return string.Empty;
        }
        private string GenerateToken(LoginModel loginModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_jwtToken.Key);

            var claims = new ClaimsIdentity(new Claim[]
            {
                    new Claim("Email",loginModel.Email)


            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,

                Expires = DateTime.UtcNow.AddDays(7),

                SigningCredentials = new SigningCredentials
                                   (new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);
            var finalToken = tokenHandler.WriteToken(tokens);
            return finalToken;
        }
    }
}
