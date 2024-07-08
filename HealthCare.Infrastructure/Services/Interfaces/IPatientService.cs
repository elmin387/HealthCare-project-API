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
        public Task<PatientGridResponse> GetPatientsAsync(PatientFilter? filter);
        public Task<PatientResponse> GetPatientByIdAsync(int id);
        public Task<PatientResponse> UpdatePatientById(PatientItem patientItem);
        public Task<PatientResponse> CreatePatientAsync(PatientItem patientItem);
        public Task<PatientResponse> DeletePatientAsync(int id);
    }
}
