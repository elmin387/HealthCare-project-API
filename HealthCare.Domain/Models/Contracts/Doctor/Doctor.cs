using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.Doctor
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DoctorTitle DoctorLastName { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
    public enum DoctorTitle
    {
        Specialist,
        SpecialistInternship,
        Nurse
    }
}
