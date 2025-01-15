using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> _sign;

        public AuthService(SignInManager<AppUser> sign, UserManager<AppUser> manager, IMapper mapper)
        {
            _sign = sign;
            _manager = manager;
            _mapper = mapper;
        }

        private readonly UserManager<AppUser> _manager;
        private readonly IMapper _mapper;

        public async Task<bool> LoginAsync(LoginCreateDto loginCreateDto)
        {
            AppUser? user = await _manager.FindByNameAsync(loginCreateDto.Username);
            if( user==null)
            {
                throw new Exception("User Not Found");
            }
            var result = await  _sign.PasswordSignInAsync(user, loginCreateDto.Password, loginCreateDto.IsPersistent = true,true);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
        
        public async Task Logoutasync()
        {
            await _sign.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterCreateDto registerCreateDto)
        {
            AppUser? user = _mapper.Map<AppUser>(registerCreateDto);
            if(user==null)
            {
                throw new Exception("user not found");
            }
            var result = await _manager.CreateAsync(user, registerCreateDto.Password);
           if(!result.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}
