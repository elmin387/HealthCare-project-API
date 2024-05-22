using HealthCare.Domain.Models.Contracts.Doctor;
using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    public class DoctorController : ApiControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;   
        }
        [HttpGet("DoctorsList")]
        public async Task<DoctorGridResponse> GetAsync()
        {
            return await _doctorService.DoctorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<DoctorResponse> GetDoctorByIdAsync(int id)
        {
            return await _doctorService.GetDoctorByIdAsync(id);
        }
        [HttpPut("{id}")]

        public async Task<DoctorResponse> UpdateDoctorbyIdAsync(DoctorItem request)
        {
            return await _doctorService.UpdateDoctorbyId(request);
        }
        [HttpPost]
        public async Task<DoctorResponse> CreateDoctorAsync(DoctorItem request)
        {
            return await _doctorService.CreateDoctorAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<DoctorResponse> DeletePatientAsync(int id)
        {
            return await _doctorService.DeleteDoctorAsync(id);
        }
    }
}
