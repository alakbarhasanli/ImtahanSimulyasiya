using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface ITecniciansService
    {
        Task<ICollection<Technicians>> GetAllTechnicianAsync();
        Task<Technicians> GetOneTechnicianAsync(int id, bool IsTracking = false, params string[] includes);
        Task CreateTechnicianAsync(TechnicianCreateDto technicianCreateDto);
        Task<bool> UpdateTechnicianAsync(TechnicianCreateDto technicianCreateDto, int id, bool IsTracking = false, params string[] includes);
        Task<bool> DeleteTechnicianAsync(int id, bool IsTracking = false, params string[] includes);
    }
}
