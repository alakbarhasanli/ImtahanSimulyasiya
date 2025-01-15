using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs;
using Project.BL.Helpers;
using Project.BL.Services.Abstractions;
using Project.DAL.Entitites;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly IMapper _mapper;
        private readonly INewsRepository _repo;
        private readonly IWebHostEnvironment _env;

        public NewsService(IMapper mapper, INewsRepository repo,IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
            _mapper = mapper;
            _repo = repo;
        }


        public async Task<ICollection<News>> GetAllNewsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id, bool IsTracking = false, params string[] includes)
        {
            News? news = await _repo.GetOneByIdAsync(id, IsTracking, includes);
            if (news == null)
            {
                throw new Exception("News Not Found with this id");
            }
            return news;
        }
        public async Task CreateAsync(NewsCreateDto newsCreateDto)
        {
            News? news = _mapper.Map<News>(newsCreateDto);
           
            if (news == null)
            {
                throw new Exception("News Not Found with this id");
            }
            if (newsCreateDto.NewsPhoto != null)
            {
                string rootpath = _env.WebRootPath;
                string filename = await newsCreateDto.NewsPhoto.UploadImage(Path.Combine(rootpath, "Uploads", "Images"));
                news.ImageUrl = filename;
            }
               await  _repo.CreateAsync(news);
                await _repo.SaveChangesAsync();
        }

        
        public async Task<bool> UpdateAsync(NewsCreateDto newsCreateDto, int id, bool IsTracking = false, params string[] includes)
        {
            News? news = _mapper.Map<News>(newsCreateDto);
            
            if (news == null)
            {
                throw new Exception("News Not Found ");
            }
            var existingNews = await _repo.GetOneByIdAsync(id, IsTracking, includes);
            if (existingNews == null)
            {
                throw new Exception("News Not Found with this id ");
            }
            _repo.UpdateAsync(existingNews);
            await _repo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id, bool IsTracking = false, params string[] includes)
        {
            var news = await _repo.GetOneByIdAsync(id, IsTracking, includes);
            if (news == null)
            {
                throw new Exception("News Not Found with this id ");
            }
            _repo.DeleteAsync(news);
            await _repo.SaveChangesAsync();
            return true;

        }


    }
}
