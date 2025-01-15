using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(RegisterCreateDto registerCreateDto);
        public Task<bool> LoginAsync(LoginCreateDto loginCreateDto);
        public Task Logoutasync();
    }
}
