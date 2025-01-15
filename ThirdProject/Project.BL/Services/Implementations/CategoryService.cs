using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entitites;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;

        public CategoryService(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool IsTracking = false, params string[] includes)
        {
            Category? category = await _repo.GetOneByIdAsync(id, IsTracking, includes);
            if (category == null)
            {
                throw new Exception("Category Not Found with this id");
            }
            return category;
        }
        public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            Category? category = _mapper.Map<Category>(categoryCreateDto);
            if (category == null)
            {
                throw new Exception("Category Not Found with this id");
            }
            await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var category = await _repo.GetOneByIdAsync(id, IsTracking, includes);
            if (category == null)
            {
                throw new Exception("Category Not Found with this id ");
            }
            _repo.DeleteAsync(category);
            await _repo.SaveChangesAsync();
            return true;

        }

    }
}
