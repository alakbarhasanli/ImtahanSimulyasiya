using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;

        public AuthService(IMapper mapper, UserManager<AppUser> user, SignInManager<AppUser> sign, RoleManager<IdentityRole> role)
        {
            _mapper = mapper;
            _user = user;
            _sign = sign;
            _role = role;
        }

        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _sign;
        private readonly RoleManager<IdentityRole> _role;
        public async Task<bool> LoginAsync(LoginAuthDto loginAuthDto)
        {
            AppUser? user = await _user.FindByNameAsync(loginAuthDto.Username);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            var result= await _sign.PasswordSignInAsync(user, loginAuthDto.Password, loginAuthDto.IsPersistent=true, true);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> LogoutAsync()
        {
            await _sign.SignOutAsync();
            return true;
        }

        public async Task<bool> RegisterAsync(RegisterAuthDto registerAuthDto)
        {
            AppUser? user = _mapper.Map<AppUser>(registerAuthDto);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            await _role.CreateAsync(new IdentityRole("admin"));
            await _role.CreateAsync(new IdentityRole("user"));
            var result = await _user.CreateAsync(user);
            if(!result.Succeeded)
            {
                throw new Exception("Dont Registered");
            }
            await _user.AddToRoleAsync(user, "user");
            return true;
            
        }
    }
}
