using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Interfaces
{
    public interface IPatientRepository
    {
        public Task<PatientGridResponse> GetPatientsAsync(PatientFilter filter);
        public Task<PatientItem> GetPatientByIdAsync(int id);
        public Task<PatientItem> UpdatePatientByIdAsync(PatientItem request);
        public Task<PatientItem> CreatePatient(PatientItem request);
        public Task<(bool isSuccess, string patientName)> DeletePatient(int id);
    }
}
