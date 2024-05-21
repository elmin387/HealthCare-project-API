using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> entity=null;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entity = _dbContext.Set<T>();
        }

        public IQueryable<T> Read() 
        {
            return entity;
        }
    }
}
