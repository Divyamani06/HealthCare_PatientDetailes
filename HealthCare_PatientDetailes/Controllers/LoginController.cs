using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_PatientDetailes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPatientDetailsService _details;

        public LoginController(IPatientDetailsService patientDetailsService)
        {
            _details= patientDetailsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public  IActionResult  LoginUser(LoginModel loginModel)
        {
            var post= _details.LoginPatientDetails(loginModel);
            if(!string.IsNullOrWhiteSpace(post))
            {
                return Ok(post);
            }
            return Unauthorized();
            
            

        }

    }
}
