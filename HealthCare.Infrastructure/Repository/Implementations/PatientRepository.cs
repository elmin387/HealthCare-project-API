using HealthCare.Domain.Common;
using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Entities;
using HealthCare.Infrastructure.Common;
using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Implementations
{
    public class PatientRepository:IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Patient> _genericRepository;

        public PatientRepository(ApplicationDbContext dbContext, IGenericRepository<Patient> genericRepository)
        {
            _dbContext = dbContext;
            _genericRepository = genericRepository;
        }
        public async Task<PatientGridResponse> GetPatientsAsync(PatientFilter filter)
        {

            PatientGridResponse response = new PatientGridResponse();
            var patients = await _genericRepository.Read()
                                                   .GlobalFilter()
                                                   .FilterPatients(filter)
                                                   .SortPaginate(filter, response)
                                                   .Select(p=> new PatientItem
            {
                PatientId = p.PatientId,
                PatientName = p.PatientName,
                Address = p.Address,
                Telephone = p.Telephone,
                Gender = (Domain.Models.Contracts.Patient.Gender)p.Gender,
            }).ToListAsync();

            response.Data = patients;
            return response;

        }
        public async Task<PatientResponse> GetPatientByIdAsync(int id)
        {
            PatientResponse response = new PatientResponse();
            var item = await _dbContext.Patients.Where(p=>p.PatientId == id).Select(p => new PatientItem
            {
                PatientId = p.PatientId,
                PatientName = p.PatientName,
                Telephone = p.Telephone,
                Address = p.Address,
                Gender = (Domain.Models.Contracts.Patient.Gender)p.Gender
            }).FirstOrDefaultAsync();
            response.item = item;
            return response;
            
           
        }
        public  async Task<PatientResponse> UpdatePatientByIdAsync(PatientItem request)
        {
            PatientResponse response = new PatientResponse();

            Patient obj = new Patient();
            obj.PatientId = request.PatientId;
            obj.PatientName = request.PatientName;
            obj.Telephone = request.Telephone;
            obj.Address = request.Address;
            obj.Gender = (Domain.Models.Entities.Gender)request.Gender;
            if (obj != null)
            {
                _dbContext.Patients.Update(obj);
                await _dbContext.SaveChangesAsync();
                return await GetPatientByIdAsync(obj.PatientId);
            }
            return response;

        }
        public async Task<PatientResponse> CreatePatient(PatientItem request)
        {
            PatientResponse response = new PatientResponse();

            Patient obj = new Patient
            { PatientId = request.PatientId,
                PatientName = request.PatientName,
                Address = request.Address,
                Telephone = request.Telephone,
                Gender = (Domain.Models.Entities.Gender)request.Gender };
            if (obj != null)
            {
                await _dbContext.Patients.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return await GetPatientByIdAsync(obj.PatientId);
            }
            return response;
        }
        public async Task<PatientResponse> DeletePatient(int id)
        {
            PatientResponse obj = new PatientResponse();
            var item = await _genericRepository.SoftDeleteAsync(id);
            if (item != null)
            {
               await _dbContext.SaveChangesAsync();
            }
            return obj;

        }
    }
}
