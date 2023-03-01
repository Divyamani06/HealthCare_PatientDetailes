using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_PatientDetailes.Controllers
{
    [Authorize]
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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAllPatient()
        {

            var getDetails = _patientdetail.GetPatientDetails();
            return Ok(getDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("patientId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPatientDetailsById(Guid id)
        {
            var getDetailsById = _patientdetail.GetPatientDetailsById(id);
            if (getDetailsById != null)
            {
                return Ok(getDetailsById);
            }
            return NotFound();
        }
    }
}
