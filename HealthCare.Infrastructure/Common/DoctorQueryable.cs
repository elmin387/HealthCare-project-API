using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Common
{
    public static class DoctorQueryable
    {
        public static IQueryable<Doctor> FilterDoctors(this IQueryable<Doctor> query, DoctorFilter request)
        {
          if (request.DoctorId != null)
            {
                return query.Where(d=>d.DoctorId == request.DoctorId);
            }
          if (!string.IsNullOrEmpty(request.Name))
            {
                return query.Where(d=>d.DoctorName == request.Name);
            }
          return query;
        }
    }
}
