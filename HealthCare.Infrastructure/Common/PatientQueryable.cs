using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Common
{
    public static class PatientQueryable
    {
        public static IQueryable<Patient> FilterPatients (this IQueryable<Patient> query, PatientFilter request) 
        {
            return query.Where(p =>
            ((request.PatientId == null)
                    || p.PatientId.Equals(request.PatientId))

                &&

                (string.IsNullOrEmpty(request.Name)
                    || p
                        .PatientName
                        .ToLower()
                        .Contains(request.Name.ToLower()))

                       );
        }

    }
}
