using HealthCare.Domain.Models.Contracts.PatientReport;
using HealthCare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    public class ReportController : ApiControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{id}")]
        public async Task<ReportResponse> GetReport(int id)
        {
            return await _reportService.Get(id);
        }

        [HttpPost]
        public async Task<ReportResponse> AddReport(PatientReportItem request)
        {
            return await _reportService.Add(request);
        }
    }
}
