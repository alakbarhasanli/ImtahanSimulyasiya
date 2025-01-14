using AutoMapper;
using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles
{
    public class TechnicianProfile:Profile
    {
        public TechnicianProfile()
        {
            CreateMap<TechnicianCreateDto, Technicians>().ReverseMap();
        }
    }
}
