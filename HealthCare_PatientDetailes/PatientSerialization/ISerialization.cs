using HealthCare_PatientDetailes.Model;

namespace HealthCare_PatientDetailes.PatientSerialization
{
    public interface ISerialization<T> where T : class
    {
       
        List<T> DeSerializePatient();
        
    }
}
