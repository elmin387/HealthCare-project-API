using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Entities
{
    public class Patient:BaseEntity
    {
        [Key]
        public int PatientId { get; set; }
        [StringLength(100)]
        public string PatientName { get; set; }
        public Gender Gender { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? Telephone { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }

}
