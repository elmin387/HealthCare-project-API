using HealthCare.Domain.Models.Contracts.Doctor;
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
    public class DoctorRepository:IDoctorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Doctor> _genericRepository;

        public DoctorRepository(ApplicationDbContext dbContext, IGenericRepository<Doctor> genericRepository) 
        { 
            _dbContext = dbContext;
            _genericRepository = genericRepository;
        }
        public async Task<DoctorGridResponse> GetDoctorsAsync()
        {
            DoctorGridResponse response = new DoctorGridResponse();
           
            var data = await _genericRepository.Read().GlobalFilter().Select(doctor => new DoctorItem
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                LastName = doctor.LastName,
                Code = doctor.Code,
                Title = (Domain.Models.Contracts.Doctor.DoctorTitle)doctor.Title,


            }).ToListAsync();
            response.Data = data;
            return response;

        }
        public async Task<DoctorResponse> GetDoctorByIdAsync(int id)
        {
            DoctorResponse response = new DoctorResponse();

            var item = await _dbContext.Doctors.Where(d=>d.DoctorId==id).Select(doctor=>new DoctorItem
            {
                DoctorId=doctor.DoctorId,
                Code = doctor.Code,
                DoctorName= doctor.DoctorName,
                LastName = doctor.LastName,
                Title = (Domain.Models.Contracts.Doctor.DoctorTitle)doctor.Title,

            }).FirstOrDefaultAsync();
            response.item = item;

           return response;
        }

        public async Task<DoctorResponse> UpdateDoctorByIdAsync(DoctorItem request)
        {
            DoctorResponse response = new DoctorResponse();
            var item =await _dbContext.Doctors.Where(d => d.DoctorId == request.DoctorId).Select(doctor => new Doctor
            {
                DoctorId = request.DoctorId,
                Code = request.Code,
                DoctorName = request.DoctorName,
                LastName = request.LastName,
                Title = (Domain.Models.Entities.DoctorTitle)request.Title,
            }).FirstOrDefaultAsync();
            if (item != null)
            {
                _dbContext.Doctors.Update(item);
                await _dbContext.SaveChangesAsync();
            }

            return await GetDoctorByIdAsync(item.DoctorId);
        }

        public async Task<DoctorResponse> CreateDoctor(DoctorItem request)
        {
            var response = new DoctorResponse();
            var item = await _dbContext.Doctors.Select(doctor => new Doctor
            {
                DoctorId = request.DoctorId,
                Code = request.Code,
                DoctorName = request.DoctorName,
                LastName = request.LastName,
                Title = (Domain.Models.Entities.DoctorTitle)request.Title,
            }).FirstOrDefaultAsync();
            if (item != null)
            {
                await _dbContext.Doctors.AddAsync(item);
                await _dbContext.SaveChangesAsync();
                return await GetDoctorByIdAsync(item.DoctorId);
            }

            return response;

        }
        public async Task<DoctorResponse> DeleteDoctor(int id)
        {
            DoctorResponse response = new DoctorResponse();
             var deletedDoctor = await _genericRepository.SoftDeleteAsync(id);
            if (deletedDoctor != null)
            {
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }
    }
}
