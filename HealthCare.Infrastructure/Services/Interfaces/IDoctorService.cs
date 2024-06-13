using HealthCare.Domain.Models.Contracts.Doctor;
using HealthCare.Domain.Models.Contracts.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IDoctorService
    {
        public Task<DoctorGridResponse> DoctorsAsync(DoctorFilter filter);
        public Task<DoctorResponse> GetDoctorByIdAsync(int id);
        public Task<DoctorResponse> UpdateDoctorbyId(DoctorItem request);
        public Task<DoctorResponse> CreateDoctorAsync(DoctorItem request);
        public Task<DoctorResponse> DeleteDoctorAsync(int id);

    }
}
