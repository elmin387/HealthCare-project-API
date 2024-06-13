using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Interfaces
{
    public interface IAcceptanceRepository
    {
        public Task<AcceptanceGridResponse> GetAcceptances(PatientAcceptanceFilter filterAcceptance);
        public Task<AcceptanceResponse> GetById(int id);
        public Task<AcceptanceResponse> UpdateById(PatientAcceptanceItem request);
        public Task<AcceptanceResponse> AddNew(PatientAcceptanceItem request);
        public Task<AcceptanceResponse> DeleteAcceptance(int id);
    }
}
