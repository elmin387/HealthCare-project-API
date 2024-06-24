using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Entities
{
    public class PatientReport:BaseEntity
    {
        [Key]
        public int PatientReportId { get; set; }
        public int AcceptanceId { get; set; }
        public PatientAcceptance? Acceptance { get; set; }
        [StringLength(1000)]
        public string ReportDescription { get; set; }
        public DateTime DateTimeOfReport { get; set; }
    }
}
