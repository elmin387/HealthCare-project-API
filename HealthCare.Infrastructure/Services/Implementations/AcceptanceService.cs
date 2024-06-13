using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using HealthCare.Infrastructure.Repository.Interfaces;
using HealthCare.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class AcceptanceService:IAcceptanceService
    {
        private readonly IAcceptanceRepository _acceptanceRepository;

        public AcceptanceService(IAcceptanceRepository acceptanceRepository)
        {
            _acceptanceRepository= acceptanceRepository;
        }
        public async Task<AcceptanceGridResponse> Get(PatientAcceptanceFilter fiterAcceptance)
        {
            return await _acceptanceRepository.GetAcceptances(fiterAcceptance);
        }
        public async Task<AcceptanceResponse> GetById(int id)
        {
            return await _acceptanceRepository.GetById(id);
        }

        public async Task<AcceptanceResponse> UpdateById(PatientAcceptanceItem request)
        {
            return await _acceptanceRepository.UpdateById(request);
        }

        public async Task<AcceptanceResponse> AddNew(PatientAcceptanceItem request)
        {
            return await _acceptanceRepository.AddNew(request);
        }

        public async Task<AcceptanceResponse> DeleteAcceptance(int id)
        {
            return await _acceptanceRepository.DeleteAcceptance(id);
        }
    }
}
