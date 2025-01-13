using AutoMapper;
using FirstProject.BL.DTOs;
using FirstProject.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Profiles
{
    public class CardItemProfile:Profile
    {
        public CardItemProfile()
        {
            CreateMap<CardItemCreateDto, CardItem>().ReverseMap();
        }
    }
}
