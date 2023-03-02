using Newtonsoft.Json;

namespace HealthCare_PatientDetailes.PatientSerialization
{
    public class Serialization<T>:ISerialization<T> where T : class
    {
        private readonly IConfiguration _configration;

        public Serialization(IConfiguration configuration) 
        {   
            _configration=configuration;
        }

        public List<T> DeSerializePatient()
        {
            var json = _configration.GetValue<string>("JSON:jsonFile");
            var jsonvalue = File.ReadAllText(json);
            if (string.IsNullOrEmpty(jsonvalue))
            {
                return new List<T>();
            }
            var item=JsonConvert.DeserializeObject<List<T>>(jsonvalue);
            return item ?? new List<T>();

         
        }
       
    }
}
