using HealthCare.Domain.Models.Contracts.Doctor;
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
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<DoctorGridResponse> DoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }
        public async Task<DoctorResponse> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }
        public async Task<DoctorResponse> UpdateDoctorbyId(DoctorItem request)
        {
            return await _doctorRepository.UpdateDoctorByIdAsync(request);
        }

        public async Task<DoctorResponse> CreateDoctorAsync(DoctorItem request)
        {
            return await _doctorRepository.CreateDoctor(request);
        }
        public async Task<DoctorResponse> DeleteDoctorAsync(int id)
        {
            return await _doctorRepository.DeleteDoctor(id);
        }
    }
}
