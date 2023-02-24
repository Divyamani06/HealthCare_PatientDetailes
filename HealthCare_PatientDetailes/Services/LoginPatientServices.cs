using HealthCare_PatientDetailes.Context;

namespace HealthCare_PatientDetailes.Services
{
    public class LoginPatientServices
    {
        private readonly PatientDbContext _dbcontext;

        public LoginPatientServices(PatientDbContext dbContext) 
        {
            _dbcontext=dbContext;
        }

    }
}
