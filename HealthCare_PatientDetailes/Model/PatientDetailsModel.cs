using System.ComponentModel.DataAnnotations;

namespace HealthCare_PatientDetailes.Model
{
    
    public class PatientDetailsModel
    {
        [Key]
        public Guid patientId { get; set; }
        public string firstName { get; set;}
        public string lastName { get; set;}
        public string gender { get; set;}
        public DateTime dateOfBirth { get; set;}
        public string addressLine1 { get; set;}
        public string addressLine2 { get; set;}
        public string city { get; set;}
        public string state { get; set;}
        public string postalCode { get; set;}
    }
}
