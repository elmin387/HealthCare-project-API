using HealthCare.Domain.Common;
using HealthCare.Infrastructure.Identity;
using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Implementations;
using HealthCare.Infrastructure.Repository.Interfaces;
using HealthCare.Infrastructure.Services.Implementations;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HealthCare.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("HealthCare.API")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var applicationContext = serviceProvider.GetService<ApplicationDbContext>();

            ApplicationDbContextSeed.SeedData(
                userManager,
                roleManager,
                configuration.GetSection("Admins").Get<SeedAdminModel>(),
                applicationContext);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>(x => new EmailService(
                    configuration["EmailSender:Host"],
                    configuration.GetValue<int>("EmailSender:Port"),
                    configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    configuration["EmailSender:UserName"],
                    configuration["EmailSender:Password"],
                    env.WebRootPath
                ));
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService,PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAcceptanceRepository, AcceptanceRepository>();
            services.AddScoped<IAcceptanceService, AcceptanceService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

    }
}