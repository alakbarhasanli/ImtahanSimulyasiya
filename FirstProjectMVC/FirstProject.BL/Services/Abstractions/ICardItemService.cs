using FirstProject.BL.DTOs;
using FirstProject.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Services.Abstractions
{
    public interface ICardItemService
    {
        Task<ICollection<CardItem>> GetAllCArdItemAsync();
        Task<CardItem> GetCardItemByIdAsync(int id, bool IsTracking =false,params string[] includes);
        Task CreateCardItemAsync(CardItemCreateDto cardItemCreateDto);
        Task<bool> UpdateCardItemAsync(CardItemCreateDto cardItemCreateDto, int id, bool IsTracking = false, params string[] includes);
        Task<bool> SoftDeleteCardItemAsync(int id, bool IsTracking = false, params string[] includes);
        Task<bool> HardDeleteCardItemAsync( int id, bool IsTracking = false, params string[] includes);
    }
}
