using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_PatientDetailes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientDetailsService _patientdetail;

        public PatientController(IPatientDetailsService patientDetaile)
        {

            _patientdetail= patientDetaile;
        }

        /// <summary>
        /// GetAllDetails
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetAllPatientDetails")]
        public IActionResult GetAllPatient()
        {

            var details = _patientdetail.GetPatientDetails();
            return Ok(details);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("GetPatientDetailsById")]
        public IActionResult GetPatientDetailsById(Guid id)
        {
            var details = _patientdetail.GetPatientDetailsById(id);
            return Ok(details);
        }
    }
}
