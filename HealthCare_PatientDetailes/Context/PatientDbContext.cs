using HealthCare_PatientDetailes.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare_PatientDetailes.Context
{
    public class PatientDbContext: DbContext
    {

        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }
        public DbSet<PatientDetailsModel> PatientDetails { get; set; }
    }
}
