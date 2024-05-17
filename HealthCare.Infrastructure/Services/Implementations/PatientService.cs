using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Infrastructure.Repository.Interfaces;
using HealthCare.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<PatientItem>> GetPatientsAsync()
        {
           return  await _patientRepository.GetPatientsAsync();
        }
        public async Task<PatientItem> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }
        public async Task<PatientItem> UpdatePatientById(PatientItem patientItem)
        {
            return await _patientRepository.UpdatePatientByIdAsync(patientItem);
        }
        public async Task<PatientItem> CreatePatientAsync(PatientItem patientItem)
        {
            return await _patientRepository.CreatePatient(patientItem);
        }
 
          
    }
}

