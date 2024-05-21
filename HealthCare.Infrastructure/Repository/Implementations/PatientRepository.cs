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
            //var patientItems = await _dbContext.Patients.Select(patient => new PatientItem
            //{
            //    PatientId = patient.PatientId,
            //    PatientName = patient.PatientName,
            //    Telephone = patient.Telephone,
            //    Address = patient.Address,
            //    Gender = (Domain.Models.Contracts.Patient.Gender)patient.Gender,

            //}).ToListAsync();
            PatientGridResponse response = new PatientGridResponse();
            var patients = await _genericRepository.Read()
                                                   .GlobalFilter()
                                                   .FilterPatients(filter)
                                                   .SortPaginate(filter, response)
            /*var patients = await _dbContext.Patients*/.Select(p=> new PatientItem
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
        public async Task<PatientItem> GetPatientByIdAsync(int id)
        {
            var patient = await _dbContext.Patients.Where(p=>p.PatientId == id).Select(p => new PatientItem
            {
                PatientId = p.PatientId,
                PatientName = p.PatientName,
                Telephone = p.Telephone,
                Address = p.Address,
                Gender = (Domain.Models.Contracts.Patient.Gender)p.Gender
            }).FirstOrDefaultAsync();
            return patient;
            
           
        }
        public  async Task<PatientItem> UpdatePatientByIdAsync(PatientItem request)
        {
            Patient obj = new Patient();
            obj.PatientId = request.PatientId;
            obj.PatientName = request.PatientName;
            obj.Telephone = request.Telephone;
            obj.Address = request.Address;
            obj.Gender = (Domain.Models.Entities.Gender)request.Gender;
             _dbContext.Patients.Update(obj);
             await _dbContext.SaveChangesAsync();
            return await GetPatientByIdAsync(obj.PatientId);
        }
        public async Task<PatientItem> CreatePatient(PatientItem request)
        {
            Patient obj = new Patient
            { PatientId = request.PatientId,
                PatientName = request.PatientName,
                Address = request.Address,
                Telephone = request.Telephone,
                Gender = (Domain.Models.Entities.Gender)request.Gender };
            _dbContext.Patients.Add(obj);
            await _dbContext.SaveChangesAsync();
            return await GetPatientByIdAsync(obj.PatientId);
        }
        public async Task<(bool isSuccess, string patientName)> DeletePatient(int id)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(x=>x.PatientId==id);
            if (patient == null)
            {   
                return (false, null);
            }
             _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync(true);
            return (true, patient.PatientName);
        }
    }
}
