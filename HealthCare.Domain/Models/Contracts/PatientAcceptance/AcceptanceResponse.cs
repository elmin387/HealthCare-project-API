using HealthCare.Domain.Common;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Domain.Models.Contracts.Patient
{
    public class AcceptanceResponse:BaseResponse
    {
        public PatientAcceptanceItem item { get; set; }
    }
}
