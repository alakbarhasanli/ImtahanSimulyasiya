using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs;
using Project.BL.Helpers;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _repo;
        private readonly IWebHostEnvironment _env;

        public DoctorService(IMapper mapper, IDoctorRepository repo, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _repo = repo;
            _env = env;
        }

        public async Task CreateAsync(DoctorCreateDto doctorCreateDto)
        {
            Doctors? doctors = _mapper.Map<Doctors>(doctorCreateDto);
            doctors.CreatedAt = DateTime.Now;
            if(doctorCreateDto.DoctorPhoto!=null)
            {
                string rootpath = _env.WebRootPath;
               string filename= await doctorCreateDto.DoctorPhoto.ImageUpload(Path.Combine(rootpath, "Uploads", "Image"));
                doctors.ImageUrl = filename;
            }
            await _repo.CreateAsync(doctors);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctors = await _repo.GetOneByIdAsync(id);
            if (doctors == null)
            {
                throw new Exception("Doctor  Not Found");
            }
            _repo.Delete(doctors);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Doctors>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Doctors> GetOneByIdAsync(int id)
        {
            Doctors? doctors = await _repo.GetOneByIdAsync(id);
            if (doctors == null)
            {
                throw new Exception("Doctor Not Found");
            }
            return doctors;
        }

        public async Task<bool> UpdateAsync(DoctorCreateDto doctorCreateDto, int id)
        {
            Doctors? doctors = _mapper.Map<Doctors>(doctorCreateDto);
            if(doctors==null)
            {
                throw new Exception("Not found");
            }
            doctors.Id = id;
            if (doctorCreateDto.DoctorPhoto != null)
            {
                string rootpath = _env.WebRootPath;
                string filename = await doctorCreateDto.DoctorPhoto.ImageUpload(Path.Combine(rootpath, "Uploads", "Image"));
                doctors.ImageUrl = filename;
            }

            var existingDoctors = await _repo.GetOneByIdAsync(id);
            if (existingDoctors == null)
            {
                throw new Exception("Doctor Not Found");
            }
            _repo.Update(doctors);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
