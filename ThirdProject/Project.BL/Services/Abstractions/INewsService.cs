using Project.BL.DTOs;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface INewsService
    {
        Task<ICollection<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(int id,bool IsTracking=false,params string[] includes);
        Task CreateAsync(NewsCreateDto newsCreateDto);
        Task<bool> UpdateAsync(NewsCreateDto newsCreateDto, int id, bool IsTracking = false, params string[] includes);
        Task<bool> DeleteAsync( int id, bool IsTracking = false, params string[] includes);

    }
}
