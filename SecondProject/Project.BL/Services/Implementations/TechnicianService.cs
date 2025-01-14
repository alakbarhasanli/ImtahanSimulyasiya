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
    public class TechnicianService : ITecniciansService
    {
        private readonly ITechnicianReadRepository _read;
        private readonly ITechnicianWriteRepository _write;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviroment;

        public TechnicianService(ITechnicianReadRepository read, ITechnicianWriteRepository write, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
            _enviroment = enviroment;
        }

        public async Task CreateTechnicianAsync(TechnicianCreateDto technicianCreateDto)
        {
            var technician = _mapper.Map<Technicians>(technicianCreateDto);
            if (technician == null)
            {
                throw new Exception("Technician Not Found");
            }
            if (technicianCreateDto.TechniciansPhoto != null)
            {
                string rootPath = _enviroment.WebRootPath;
                string fileName = await technicianCreateDto.TechniciansPhoto.UploadImage(rootPath, "Uploads","Images");


                technician.ImageUrl = fileName;

            }
            await _write.CreateAsync(technician);
            await _write.SaveChangesAsync();
        }

        public async Task<bool> DeleteTechnicianAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var technician = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (technician == null)
            {
                throw new Exception("Technician Not Found");
            }
            _write.Delete(technician);
            await _write.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Technicians>> GetAllTechnicianAsync()
        {
            var technician = await _read.GetAllAsync();
            return technician;
        }

        public async Task<Technicians> GetOneTechnicianAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var technician = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (technician == null)
            {
                throw new Exception("Technician Not Found");
            }
            return technician;
        }

        public async Task<bool> UpdateTechnicianAsync(TechnicianCreateDto technicianCreateDto, int id, bool IsTracking = false, params string[] includes)
        {
            var technicians = _mapper.Map<Technicians>(technicianCreateDto);
            if (technicians == null)
            {
                throw new Exception("Technician Not Found");
            }
            var existingTechnician = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (existingTechnician == null)
            {
                throw new Exception("existingTechnician Not Found");
            }

            _write.Update(existingTechnician);
            await _write.SaveChangesAsync();
            return true;
        }
    }
}
