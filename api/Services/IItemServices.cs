using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;

namespace api.Services
{
    public interface IItemServices
    {
        Task<List<ItemResponseDto>> GetAllAsync();
        Task<ItemResponseDto?> GetByIdAsync(int id); 
        Task<ItemResponseDto> AddItemAsync(ItemCreateDto item);
    }
}