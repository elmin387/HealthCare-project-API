using HealthCare.Domain.Models.Contracts.PatientReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.Interfaces
{
    public interface IReportService
    {
        public Task<ReportResponse> Add(PatientReportItem request);
        public Task<ReportResponse> Get(int acceptanceId);
    }
}
