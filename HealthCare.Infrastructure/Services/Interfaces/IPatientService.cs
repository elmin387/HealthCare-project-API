using HealthCare.Domain.Models.Contracts.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IPatientService
    {
        public Task<IEnumerable<PatientItem>> GetPatientsAsync();
        public Task<PatientItem> GetPatientByIdAsync(int id);
        public Task<PatientItem> UpdatePatientById(PatientItem patientItem);
        public Task<PatientItem> CreatePatientAsync(PatientItem patientItem);
    }
}
