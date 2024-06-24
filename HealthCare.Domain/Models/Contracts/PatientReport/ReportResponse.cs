using HealthCare.Domain.Common;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using HealthCare.Domain.Models.Contracts.PatientReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.PatientReport
{
    public class ReportResponse:BaseResponse
    {
        public PatientReportItem item { get; set; }
    }
}
