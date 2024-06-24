using HealthCare.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.PatientReport
{
    public class ReportFilter:BaseFilter
    {
        public int? ReportId { get; set; }
        [MaxLength(200)]
        public string? Name { get; set; }

    }
}
