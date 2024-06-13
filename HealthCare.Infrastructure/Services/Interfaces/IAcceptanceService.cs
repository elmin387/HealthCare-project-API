using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IAcceptanceService
    {
        public Task<AcceptanceGridResponse> Get(PatientAcceptanceFilter fiterAcceptance);
        public Task<AcceptanceResponse> GetById(int id);
        public Task<AcceptanceResponse> UpdateById(PatientAcceptanceItem request);
        public Task<AcceptanceResponse> AddNew(PatientAcceptanceItem request);
        public Task<AcceptanceResponse> DeleteAcceptance(int id);
    }
}
