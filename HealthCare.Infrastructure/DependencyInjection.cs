using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Implementations;
using HealthCare.Infrastructure.Repository.Interfaces;
using HealthCare.Infrastructure.Services.Implementations;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HealthCare.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("HealthCare.API")));
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            //var applicationContext = serviceProvider.GetService<ApplicationDbContext>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAcceptanceRepository, AcceptanceRepository>();
            services.AddScoped<IAcceptanceService, AcceptanceService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

    }
}