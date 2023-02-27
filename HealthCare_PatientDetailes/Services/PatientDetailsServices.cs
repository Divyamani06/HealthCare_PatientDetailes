using HealthCare_PatientDetailes.Authentication;
using HealthCare_PatientDetailes.Context;
using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.PatientSerialization;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCare_PatientDetailes.Services
{
    public class PatientDetailsServices :IPatientDetailsService
    {
        private readonly ISerialzation _serialze;
        private readonly JwtToken _jwtToken;

        public PatientDetailsServices(ISerialzation serialzation, IOptions<JwtToken> options) 
        {
            _serialze=serialzation;
            _jwtToken = options.Value;
        }

        /// <summary>
        /// AllDetailsFromPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientDetailsModel> GetPatientDetails()
        {
            var details = _serialze.DeSerialzePatient();
            return details;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  PatientDetailsModel  GetPatientDetailsById(Guid id)
        {
            var getdetailsbyId = _serialze.DeSerialzePatient();
            var details = getdetailsbyId.FirstOrDefault(x => x.patientId == id);

            return details;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string LoginPatientDEtails(LoginModel loginModel)
        {

            string user = null;
            if (loginModel.Email=="testmail@gmail.com" && loginModel.Password == "testpassword")
            {
                var token = GenerateToken(loginModel);
                return token;
            }

            return user;
        }
        
        private string GenerateToken(LoginModel loginModel) 
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtToken.Token);

            var claims = new ClaimsIdentity(new Claim[]
            {
                    new Claim("Email",loginModel.Email),
                    new Claim(ClaimTypes.Name,loginModel.Password),
                    
            });


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,

                Expires = DateTime.UtcNow.AddDays(7),

                SigningCredentials = new SigningCredentials
                                   (new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);
            var fianleToken = tokenHandler.WriteToken(tokens);
            return fianleToken;
        }
     
        
    }
}
