using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> Read();
    }
}
