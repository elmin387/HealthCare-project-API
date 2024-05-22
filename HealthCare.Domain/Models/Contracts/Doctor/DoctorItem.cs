using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.Doctor
{
    public class DoctorItem
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DoctorTitle Title { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
    }
    public enum DoctorTitle
    {
        Specialist,
        SpecialistInternship,
        Nurse
    }
}
