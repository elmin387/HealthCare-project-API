using HealthCare.Domain.Models.Contracts.Patient;
using HealthCare.Domain.Models.Contracts.PatientAcceptance;
using HealthCare.Domain.Models.Entities;
using HealthCare.Infrastructure.Common;
using HealthCare.Infrastructure.Persistance;
using HealthCare.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Repository.Implementations
{
    public class AcceptanceRepository:IAcceptanceRepository
    {
        private readonly IGenericRepository<PatientAcceptance> _genericRepository;
        private readonly ApplicationDbContext _dbContext;

        public AcceptanceRepository(IGenericRepository<PatientAcceptance> genericRepository, ApplicationDbContext dbContext) 
        { 
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }
        public async Task<AcceptanceGridResponse> GetAcceptances(PatientAcceptanceFilter filterAcceptance) 
        {
            AcceptanceGridResponse response = new AcceptanceGridResponse();
            var data =await _genericRepository.Read()
                                         .GlobalFilter()
                                         .AcceptanceFilter(filterAcceptance)
                                         .SortPaginate(filterAcceptance, response)
                                         .Include(p=>p.Patient)
                                         .Include(d=>d.Doctor)
                                         .Select(x=> new PatientAcceptanceItem
                                         {
                                             PatientAcceptanceId=x.PatientAcceptanceId,
                                             PatientId=x.Patient.PatientId,
                                             PatientName = x.Patient.PatientName,
                                             DoctorId=x.Doctor.DoctorId,
                                             DoctorName = x.Doctor.DoctorName,
                                             DoctorCode = x.Doctor.Code,
                                             UrgentAcceptance =x.UrgentAcceptance,
                                             DateTimeOfAcceptance=x.DateTimeOfAcceptance
                                         }).ToListAsync();
            response.Data = data;
            return response;
        }
        public async Task<AcceptanceResponse> GetById(int id)
        {
            AcceptanceResponse response = new AcceptanceResponse();
            var acceptance = await _dbContext.PatientAcceptances.Select(a => new PatientAcceptanceItem
            {
                PatientAcceptanceId = a.PatientAcceptanceId,
                PatientId = a.Patient.PatientId,
                PatientName = a.Patient.PatientName,
                DoctorId = a.Doctor.DoctorId,
                DoctorName= a.Doctor.DoctorName,
                DateTimeOfAcceptance = a.DateTimeOfAcceptance,
                UrgentAcceptance=a.UrgentAcceptance,
            }).FirstOrDefaultAsync(x=>x.PatientAcceptanceId==id);
            response.item = acceptance;
            return response;
        }

        public async Task<AcceptanceResponse>UpdateById(PatientAcceptanceItem request)
        {
            AcceptanceResponse response = new AcceptanceResponse();
            if (request.DateTimeOfAcceptance < DateTime.UtcNow)
            {
                response.Success = false;
                response.Errors.Add("DateTimeOfAcceptance cannot be in the past.");
                return response;
            }
            var fetchedAcceptance = await _dbContext.PatientAcceptances.Include(d=>d.Doctor).Include(p=>p.Patient).FirstOrDefaultAsync(a=>a.PatientAcceptanceId == request.PatientAcceptanceId);
            //PatientAcceptance updatedAcceptance = new PatientAcceptance();
            if (fetchedAcceptance != null)
            {
                fetchedAcceptance.PatientAcceptanceId = request.PatientAcceptanceId;
                fetchedAcceptance.DateTimeOfAcceptance = request.DateTimeOfAcceptance;
                fetchedAcceptance.PatientId = request.PatientId;
                fetchedAcceptance.Patient.PatientName = request.PatientName;
                fetchedAcceptance.DoctorId = request.DoctorId;
                fetchedAcceptance.Doctor.DoctorName = request.DoctorName;
                fetchedAcceptance.UrgentAcceptance = request.UrgentAcceptance;
            }
            

            if (fetchedAcceptance != null)
            {
                 _dbContext.PatientAcceptances.Update(fetchedAcceptance);
                await _dbContext.SaveChangesAsync();
                return await GetById(fetchedAcceptance.PatientAcceptanceId);
            }
            return response;
           
        }
        public async Task<AcceptanceResponse> AddNew(PatientAcceptanceItem request)
        {
            AcceptanceResponse response = new AcceptanceResponse();
            if(request.DateTimeOfAcceptance < DateTime.UtcNow)
            {
                response.Success = false;
                response.Errors.Add("DateTimeOfAcceptance cannot be in the past.");
                return response;
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientId == request.PatientId);
            var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(d => d.DoctorId == request.DoctorId);
            PatientAcceptance newAcceptance = new PatientAcceptance
            {
            DateTimeOfAcceptance = request.DateTimeOfAcceptance,
            PatientId = request.PatientId,
            Patient = patient,
            DoctorId = request.DoctorId,
            Doctor=doctor,
            UrgentAcceptance = request.UrgentAcceptance
        };
           
            if (newAcceptance != null)
            {
                 _dbContext.PatientAcceptances.Add(newAcceptance);
                await _dbContext.SaveChangesAsync();
                return await GetById(newAcceptance.PatientAcceptanceId);
            }
            return response;
        }
        public async Task<AcceptanceResponse> DeleteAcceptance(int id)
        {
            AcceptanceResponse response = new AcceptanceResponse();
            var result = _genericRepository.SoftDeleteAsync(id);
            if (result != null)
            {
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }
    }
}
