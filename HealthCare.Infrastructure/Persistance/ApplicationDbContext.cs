﻿using HealthCare.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Persistance
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Doctor> Doctors=>Set<Doctor>();
        public DbSet<Patient> Patients =>Set<Patient>();
        public DbSet<PatientAcceptance> PatientAcceptances =>Set<PatientAcceptance>();
        public DbSet<PatientReport> PatientReports =>Set<PatientReport>();

    }
}
