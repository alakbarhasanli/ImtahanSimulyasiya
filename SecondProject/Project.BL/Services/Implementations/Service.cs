using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Project.BL.DTOs;
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
    public class Service : IService
    {
        private readonly IServiceReadRepository _read;
        private readonly IServiceWriteRepository _write;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviroment;

        public Service(IServiceReadRepository read, IServiceWriteRepository write, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
            _enviroment = enviroment;
        }


        public async Task CreateServiceAsync(ServiceCreatedto serviceCreatedto)
        {
            var service = _mapper.Map<DAL.Entities.Service>(serviceCreatedto);
            if (service == null)
            {
                throw new Exception("Service Not Found");
            }
            await _write.CreateAsync(service);
            await _write.SaveChangesAsync();
           

        }

        public async Task<bool> DeleteServiceAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var service = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (service == null)
            {
                throw new Exception("carditem Not Found");
            }
            _write.Delete(service);
            await _write.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<DAL.Entities.Service>> GetAllServiceAsync()
        {
            var service = await _read.GetAllAsync();
            return service;
        }

        public async Task<DAL.Entities.Service> GetOneServiceAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var service = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (service == null)
            {
                throw new Exception("carditem Not Found");
            }
            return service;
        }

        public async Task<bool> UpdateServiceAsync(ServiceCreatedto serviceCreatedto, int id, bool IsTracking = false, params string[] includes)
        {
            var service = _mapper.Map<DAL.Entities.Service>(serviceCreatedto);
            if (service == null)
            {
                throw new Exception("Service Not Found");
            }
            var existingService = await _read.GetOneByIdAsync(id, IsTracking, includes);
            if (existingService == null)
            {
                throw new Exception("existingService Not Found");
            }
            
           _write.Update(existingService);
            await _write.SaveChangesAsync();
            return true;
        }
    }
}
