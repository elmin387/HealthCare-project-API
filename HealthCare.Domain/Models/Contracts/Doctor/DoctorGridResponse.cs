using HealthCare.Domain.Common;
using HealthCare.Domain.Models.Contracts.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.Patient
{
    public class DoctorGridResponse:BaseGridResponse
    {
        public IEnumerable<DoctorItem>? Data { get; set; }
    }
}
