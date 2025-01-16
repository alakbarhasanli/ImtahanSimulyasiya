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
        public Task<bool> RegisterAsync(RegisterAuthDto registerAuthDto);
        public Task<bool> LoginAsync(LoginAuthDto loginAuthDto);
        public Task<bool> LogoutAsync();

    }
}
