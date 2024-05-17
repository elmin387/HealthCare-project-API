using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Entities
{
    public class PatientReport
    {
        [Key]
        public int PatientReportId { get; set; }
        [StringLength(500)]
        public string ReportDescription { get; set; }
        public DateTime DateTimeOfReport { get; set; }
    }
}
