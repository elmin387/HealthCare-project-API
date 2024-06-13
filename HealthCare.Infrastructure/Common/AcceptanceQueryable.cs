using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Common
{
    public static class AcceptanceQueryable
    {
        public static IQueryable<PatientAcceptance> AcceptanceFilter(this IQueryable<PatientAcceptance> query, PatientAcceptanceFilter request) 
        {
            if (request.FromDate.HasValue)
            {
                query = query.Where(a=>a.DateTimeOfAcceptance>=request.FromDate.Value);
            }
            if (request.ToDate.HasValue)
            {
                DateTime toDateEndOfDay = request.ToDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(a=>a.DateTimeOfAcceptance<= toDateEndOfDay);
            }
            return query;
        }
    }
}
