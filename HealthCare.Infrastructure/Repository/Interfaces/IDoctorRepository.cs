using HealthCare.Domain.Models.Contracts.Doctor;
using HealthCare.Domain.Models.Contracts.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Interfaces
{
    public interface IDoctorRepository
    {
        public Task<DoctorGridResponse> GetDoctorsAsync();
        public Task<DoctorResponse> GetDoctorByIdAsync(int id);
        public Task<DoctorResponse> UpdateDoctorByIdAsync(DoctorItem request);
        public Task<DoctorResponse> CreateDoctor(DoctorItem request);
        public Task<DoctorResponse> DeleteDoctor(int id);
    }
}
