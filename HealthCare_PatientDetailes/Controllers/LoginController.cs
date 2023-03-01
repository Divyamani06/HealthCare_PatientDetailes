using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_PatientDetailes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginPatientDetailService _details;

        public LoginController(ILoginPatientDetailService loginPatientDetail)
        {
           _details=loginPatientDetail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public  IActionResult  LoginUser(LoginModel loginModel)
        {
            var token= _details.LoginPatientDetails(loginModel);
            if(!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }
            return Unauthorized();
            
            

        }

    }
}
