using HealthCare_PatientDetailes.Model;
using Newtonsoft.Json;

namespace HealthCare_PatientDetailes.PatientSerialization
{
    public class Serialization:ISerialization
    {
        private readonly IConfiguration _configration;

        public Serialization(IConfiguration configuration) 
        {
            _configration=configuration;
        }

        public List<PatientDetailsModel> DeSerializePatient()
        {
            var json = _configration.GetValue<string>("JSON:jsonFile");
            var jsonvalue = File.ReadAllText(json);
            if (jsonvalue != null)
            {
                var item = JsonConvert.DeserializeObject<List<PatientDetailsModel>>(jsonvalue);
                return item ?? new List<PatientDetailsModel>();
            }
            return new List<PatientDetailsModel>();
        }
       
    }
}
