using Project.BL.DTOs;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int id, bool IsTracking = false, params string[] includes);
        Task CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<bool> DeleteAsync(int id, bool IsTracking = false, params string[] includes);
    }
}
