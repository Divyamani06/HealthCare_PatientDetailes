using HealthCare_PatientDetailes.Model;
using Newtonsoft.Json;
using System.Collections;

namespace HealthCare_PatientDetailes.PatientSerialization
{
    public class Serialization:ISerialzation
    {

        public List<PatientDetailsModel> DeSerialzePatient()
        {
            var json = File.ReadAllText(@"D:\C#-Codes\HealthCare_PatientDetailes\HealthCare_PatientDetailes\Json\PatientDataFile.json");
           
            var item = JsonConvert.DeserializeObject<List<PatientDetailsModel>>(json);
           

            
            return item;

        }
    }
}
