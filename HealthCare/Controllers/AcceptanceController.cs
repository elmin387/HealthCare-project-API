using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    public class AcceptanceController : ApiControllerBase
    {
        private readonly IAcceptanceService _acceptanceService;

        public AcceptanceController(IAcceptanceService acceptanceService)
        {
            _acceptanceService = acceptanceService;
        }
        [HttpGet]
        public async Task<AcceptanceGridResponse> GetAcceptances([FromQuery] PatientAcceptanceFilter acceptanceFilter)
        {
            return await _acceptanceService.Get(acceptanceFilter);
        }
        [HttpGet("{id}")]
        public async Task<AcceptanceResponse> GetbyIdAcceptance(int id)
        {
            return await _acceptanceService.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<AcceptanceResponse> Update(PatientAcceptanceItem request)
        {
            return await _acceptanceService.UpdateById(request);
        }

        [HttpPost]
        public async Task<AcceptanceResponse> AddNewAcceptance(PatientAcceptanceItem request)
        {
            return await _acceptanceService.AddNew(request);
        }

        [HttpDelete("{id}")]
        public async Task<AcceptanceResponse> RemoveAcceptance(int id)
        {
            return await _acceptanceService.DeleteAcceptance(id);
        }
    }
    
}
