using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.PatientReport
{
    public class PatientReportItem
    {
        public int ReportId { get; set; }
        public int AcceptanceId { get; set; }
        public string ReportDescription { get; set; }
        public DateTime DateTimeOfReport { get; set; }
    }
}
