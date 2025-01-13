using AutoMapper;
using FirstProject.BL.DTOs;
using FirstProject.BL.Helpers;
using FirstProject.BL.Services.Abstractions;
using FirstProject.DAL.Entitites;
using FirstProject.DAL.Repositories.Abstractions;
using FirstProject.DAL.Repositories.Concretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Services.Concretes
{
    public class CardItemService : ICardItemService
    {
        private readonly ICardItemReadRepository _read;
        private readonly ICardItemWriteRepository _write;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviroment;

        public CardItemService(ICardItemWriteRepository write, ICardItemReadRepository read, IMapper mapper, IWebHostEnvironment enviroment)
        {
            _write = write;
            _read = read;
            _mapper = mapper;
            _enviroment = enviroment;
        }

        public async Task<ICollection<CardItem>> GetAllCArdItemAsync()
        {
            var allCardItem = await _read.GetAllAsync();
            return allCardItem;
        }

        public async Task<CardItem> GetCardItemByIdAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var cardItem = await _read.GetOneByIDAsync(id, IsTracking, includes);
            return cardItem;
        }
        public async Task CreateCardItemAsync(CardItemCreateDto cardItemCreateDto)
        {
            var cardItem = _mapper.Map<CardItem>(cardItemCreateDto);
            if(cardItem==null)
            {
                throw new Exception("carditem Not Found");
            }
            if(cardItemCreateDto.CardPhoto!=null)
            {
                string fileName = cardItemCreateDto.CardPhoto.UploadImage(_enviroment.WebRootPath, @"/Uploads/CardPhoto/");


                cardItem.ImageUrl = @"/Uploads/CardPhoto/" + fileName;

            }
            await _write.CreateAsync(cardItem);
            await _write.SaveChangesAsync();
            
        }


        public async Task<bool> SoftDeleteCardItemAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var carditem = await  _read.GetOneByIDAsync(id, IsTracking, includes);
            if (carditem == null)
            {
                throw new Exception("carditem Not Found");
            }
            _write.SoftDelete(carditem);
            await _write.SaveChangesAsync();
            return true;


        }
        public async Task<bool> HardDeleteCardItemAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var carditem = await _read.GetOneByIDAsync(id, IsTracking, includes);
            if (carditem == null)
            {
                throw new Exception("carditem Not Found");
            }
            _write.HardDelete(carditem);
            await _write.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateCardItemAsync(CardItemCreateDto cardItemCreateDto, int id, bool IsTracking = false, params string[] includes)
        {
            var cardItem = _mapper.Map<CardItem>(cardItemCreateDto);
            cardItem.Id = id;
            if (cardItem == null)
            {
                throw new Exception("carditem Not Found");
            }

            var existingCardItem = await _read.GetOneByIDAsync(id, IsTracking, includes);
            if (existingCardItem == null)
            {
                throw new Exception("carditem Not Found");
            }
            _write.Update(cardItem);
            await _write.SaveChangesAsync();
            return true;
        }
    }
    }

