using HealthCare.Domain.Models.Contracts.PatientReport;
using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Interfaces
{
    public interface IReportRepository
    {
        public Task<ReportResponse> AddReportByAcceptance(PatientReportItem request);
        public Task<ReportResponse> GetReportByAcceptance(int acceptanceId);
    }
}
