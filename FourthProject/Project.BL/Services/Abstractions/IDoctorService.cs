using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        public Task<ICollection<Doctors>> GetAllAsync();
        public Task<Doctors> GetOneByIdAsync(int id, bool IsTracking, params string[] includes);
        public Task CreateAsync(DoctorCreateDto doctorCreateDto);
        public Task<bool> UpdateAsync(DoctorCreateDto doctorCreateDto, int id, bool IsTracking, params string[] includes);
        public Task<bool> DeleteAsync(int id, bool IsTracking, params string[] includes);
    }
}
