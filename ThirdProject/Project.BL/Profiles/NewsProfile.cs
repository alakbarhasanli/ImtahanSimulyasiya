﻿using AutoMapper;
using Project.BL.DTOs;
using Project.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Profiles
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsCreateDto, News>().ReverseMap();
        }
    }
}
