using HealthCare_PatientDetailes.Authentication;
using HealthCare_PatientDetailes.Context;
using HealthCare_PatientDetailes.PatientSerialization;
using HealthCare_PatientDetailes.Services;
using HealthCare_PatientDetailes.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<IPatientDetailsService, PatientDetailsServices>();
builder.Services.AddScoped<ISerialzation, Serialization>();


/////Database Connection

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(connectionString));






builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
