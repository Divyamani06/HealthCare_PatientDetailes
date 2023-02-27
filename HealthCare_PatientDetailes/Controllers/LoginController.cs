using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public  IActionResult  LoginUser(LoginModel loginModel)
        {
            var post= _details.LoginPatientDetails(loginModel);

            if(post != null) 
            {
                return Ok(post);
            }
            else
            {
                return Unauthorized();
            }
            

        }

    }
}
