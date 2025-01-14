using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IService
    {
        Task<ICollection<Service>> GetAllServiceAsync();
        Task<Service> GetOneServiceAsync(int id, bool IsTracking = false, params string[] includes);
        Task CreateServiceAsync(ServiceCreatedto serviceCreatedto);
        Task<bool> UpdateServiceAsync(ServiceCreatedto serviceCreatedto, int id, bool IsTracking = false, params string[] includes);
        Task<bool> DeleteServiceAsync(int id, bool IsTracking = false, params string[] includes);

    }
}
