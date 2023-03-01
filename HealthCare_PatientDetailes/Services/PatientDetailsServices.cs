using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.PatientSerialization;
using HealthCare_PatientDetailes.Services.IServices;

namespace HealthCare_PatientDetailes.Services
{
    public class PatientDetailsServices : IPatientDetailsService
    {
        private readonly ISerialization _serialze;

        public PatientDetailsServices(ISerialization serialzation)
        {
            _serialze = serialzation;
           
        }

        /// <summary>
        /// AllDetailsFromPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientDetailsModel> GetPatientDetails()
        {
            var details = _serialze.DeSerializePatient();
            return details;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PatientDetailsModel? GetPatientDetailsById(Guid? id)
        {
            var getdetailsbyId = _serialze.DeSerializePatient();
            var details = getdetailsbyId.FirstOrDefault(x => x.patientId == id);
            return details;

        }
    }
}
