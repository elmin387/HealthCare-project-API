using HealthCare.Domain.Models.Contracts.PatientReport;
using HealthCare.Infrastructure.Repository.Interfaces;
using HealthCare.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Implementations
{
    public class ReportService:IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ReportResponse> Add(PatientReportItem request)
        {
            return await _reportRepository.AddReportByAcceptance(request);
        }

        public async Task<ReportResponse> Get(int acceptanceId)
        {
            return await _reportRepository.GetReportByAcceptance(acceptanceId);
        }
    }
}
