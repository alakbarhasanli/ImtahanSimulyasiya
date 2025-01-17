using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        public Task<ICollection<Department>> GetAllAsync();
        public Task<Department> GetOneByIdAsync(int id);
        public Task CreateAsync(DepartmentCreateDto departmentCreateDto);
        public Task<bool> UpdateAsync(DepartmentCreateDto departmentCreateDto, int id);
        public Task<bool> DeleteAsync(int id    );


    }
}
