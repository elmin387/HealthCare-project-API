using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientReport;
using HealthCare.Domain.Models.Entities;
using HealthCare.Infrastructure.Common;
using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly IGenericRepository<PatientReport> _genericRepository;
        private readonly ApplicationDbContext _dbContext;

        public ReportRepository(IGenericRepository<PatientReport> genericRepository, ApplicationDbContext dbContext) 
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task<ReportResponse> AddReportByAcceptance(PatientReportItem request)
        {
            ReportResponse response  = new ReportResponse();
            var report = _dbContext.PatientReports.Where(a=>a.AcceptanceId == request.AcceptanceId).FirstOrDefault();
            if (report != null) 
            {
                response.Success = false;
                response.Errors = new List<string>();
                var info = "The report already exist";
                response.Errors.Add(info);
                return response;
            }
            PatientReport obj = new PatientReport
            {
                AcceptanceId = request.AcceptanceId,
                ReportDescription = request.ReportDescription,
                DateTimeOfReport = request.DateTimeOfReport,
            };
            await _dbContext.PatientReports.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return await GetReportByAcceptance(obj.AcceptanceId);

        }
        public async Task<ReportResponse>GetReportByAcceptance(int acceptanceId)
        {
            ReportResponse response = new ReportResponse();

            var report = await _dbContext.PatientReports.Where(r=>r.AcceptanceId==acceptanceId).Select(report=> new PatientReportItem
            {
                AcceptanceId = report.AcceptanceId,
                ReportId = report.PatientReportId,
                ReportDescription = report.ReportDescription,
                DateTimeOfReport = report.DateTimeOfReport,
            }).FirstOrDefaultAsync();

            response.item = report;
            return response;

        }
    }
}
