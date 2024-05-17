using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HealthCare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
            
        }
        [HttpGet("PatientsList", Name ="GetPatients")]
        public async Task<IEnumerable<PatientItem>> GetPatients([FromQuery] PatientFilter filter)
        {
           var result= await _patientService.GetPatientsAsync();
            if (result != null)
            {
                return result;
            }
            return Enumerable.Empty<PatientItem>();
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public async Task<PatientItem> GetPatientById(int id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        [HttpPut("{id}",Name ="UpdatePatientById")]
        public async  Task<IActionResult> UpdatePatientAsync(PatientItem patientItem)
        {
            var updatedPatient = await _patientService.UpdatePatientById(patientItem);
            if (updatedPatient != null)
            {
                return Ok(patientItem);
            }
            return NotFound("Error updating patient");
        }
        [HttpPost("AddPatient", Name ="AddPatient")]
        public async Task<IActionResult> CreatePatientAsync(PatientItem patientItem)
        {
            var newPatient = await _patientService.CreatePatientAsync(patientItem);
            if (newPatient != null)
            {
                return Ok(newPatient);
            }
            return BadRequest("Error while adding new patient");
        }


    }
}
