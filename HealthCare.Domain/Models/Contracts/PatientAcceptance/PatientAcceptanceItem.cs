using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Domain.Models.Entities;

namespace HealthCare.Domain.Models.Contracts.PatientAcceptance
{
    public class PatientAcceptanceItem
    {
        public int PatientAcceptanceId { get; set; }
        public DateTime DateTimeOfAcceptance { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool UrgentAcceptance { get; set; }

    }
}
