using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.Patient
{
    public class PatientItem
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
    }

    public enum Gender
    {
        Male=0,
        Female=1,
        Unknown=2
    }

}
