using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;

        public DepartmentService(IMapper mapper, IDepartmentRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        private readonly IDepartmentRepository _repo;
        public async Task CreateAsync(DepartmentCreateDto departmentCreateDto)
        {
            Department? department = _mapper.Map<Department>(departmentCreateDto);
            department.CreatedAt = DateTime.Now;
            await _repo.CreateAsync(department);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _repo.GetOneByIdAsync(id);
            if(department==null)
            {
                throw new Exception("Department Not Found");
            }
            _repo.Delete(department);
           await  _repo.SaveChangesAsync();
            return  true;

        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Department> GetOneByIdAsync(int id)
        {
            var department = await _repo.GetOneByIdAsync(id);
            if (department == null)
            {
                throw new Exception("Department Not Found");
            }
            return department;
        }

        public async Task<bool> UpdateAsync(DepartmentCreateDto departmentCreateDto, int id)
        {
            Department? department = _mapper.Map<Department>(departmentCreateDto);
            department.Id = id;
            if (department == null)
            {
                throw new Exception("Not found");
            }
            department.Id = id;
            

            var existingDepartment = await _repo.GetOneByIdAsync(id);
            if (existingDepartment == null)
            {
                throw new Exception(" Not Found");
            }
            _repo.Update(department);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
