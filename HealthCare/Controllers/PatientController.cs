using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HealthCare.API.Controllers
{
    public class PatientController : ApiControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
            
        }
        [HttpGet("PatientsList")]
        public async Task<PatientGridResponse> GetPatients([FromQuery] PatientFilter filter)
        {
           return  await _patientService.GetPatientsAsync(filter);

        }

        [HttpGet("{id}")]
        public async Task<PatientResponse> GetPatientById(int id)
        {
            return await _patientService.GetPatientByIdAsync(id);
 
        }

        [HttpPut("{id}")]
        public async  Task<PatientResponse> UpdatePatientAsync(PatientItem patientItem)
        {
            return await _patientService.UpdatePatientById(patientItem);
        }

        [HttpPost("AddPatient", Name ="AddPatient")]
        public async Task<PatientResponse> CreatePatientAsync(PatientItem patientItem)
        {
            return await _patientService.CreatePatientAsync(patientItem);
        }
        [HttpDelete("{id}")]
        public async Task<PatientResponse> RemovePatient(int id)
        {
        
            return await _patientService.DeletePatientAsync(id);
            
        }   

    }
}
