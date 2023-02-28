using HealthCare_PatientDetailes.Model;

namespace HealthCare_PatientDetailes.Services.IServices
{
    public interface IPatientDetailsService
    {        
        List<PatientDetailsModel> GetPatientDetails();
        PatientDetailsModel GetPatientDetailsById(Guid id);
        string LoginPatientDetails(LoginModel loginModel);
    }
}
