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
        public Task<PatientResponse> GetPatientByIdAsync(int id);
        public Task<PatientResponse> UpdatePatientByIdAsync(PatientItem request);
        public Task<PatientResponse> CreatePatient(PatientItem request);
        public Task<PatientResponse> DeletePatient(int id);
    }
}
