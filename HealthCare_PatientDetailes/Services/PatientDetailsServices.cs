using HealthCare_PatientDetailes.Context;
using HealthCare_PatientDetailes.Model;
using HealthCare_PatientDetailes.PatientSerialization;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace HealthCare_PatientDetailes.Services
{
    public class PatientDetailsServices :IPatientDetailsService
    {
        private readonly ISerialzation _serialze;

        public PatientDetailsServices(ISerialzation serialzation) 
        {
            _serialze=serialzation;
        }

        public List<PatientDetailsModel> GetPatientDetails()
        {
            var details = _serialze.DeSerialzePatient();
            return details;

        }
        
    }
}
