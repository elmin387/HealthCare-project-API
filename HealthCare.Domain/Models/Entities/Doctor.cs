using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [StringLength(50)]
        public string DoctorName { get; set; }
        public DoctorTitle DoctorLastName { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
    }
    public enum DoctorTitle
    {
        Specialist,
        SpecialistInternship,
        Nurse
    }
}
