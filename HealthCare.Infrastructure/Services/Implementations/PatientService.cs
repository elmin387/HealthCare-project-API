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

        public async Task<PatientGridResponse> GetPatientsAsync(PatientFilter filter)
        {
           return  await _patientRepository.GetPatientsAsync(filter);
        }
        public async Task<PatientResponse> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }
        public async Task<PatientResponse> UpdatePatientById(PatientItem patientItem)
        {
            return await _patientRepository.UpdatePatientByIdAsync(patientItem);
        }
        public async Task<PatientResponse> CreatePatientAsync(PatientItem patientItem)
        {
            return await _patientRepository.CreatePatient(patientItem);
        }
        public async Task<PatientResponse> DeletePatientAsync(int id)
        {
            return await _patientRepository.DeletePatient(id);
        }
 
          
    }
}

