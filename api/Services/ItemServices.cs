using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemsRepository _repo; 
        public ItemServices(IItemsRepository repo)
        {
            _repo = repo;
        }
        public async Task<ItemResponseDto> AddItemAsync(ItemCreateDto dto)
        {
            Items item = new Items(); 
            item.Name = dto.Name; 
            item.Category_id = dto.Category_id; 
            item.Price = dto.Price; 
            item.Tag = dto.Tag; 
            item.Description = dto.Description; 
            item.Image_url = dto.Image_url; 
            Items saved = await _repo.AddAsync(item); 
            return ToDto(saved); 
        }

        public async Task<List<ItemResponseDto>> GetAllAsync()
        {
           List<Items> items = await _repo.GetAllAsync(); 

           return items.Select(ToDto).ToList(); 
        }

        public async Task<ItemResponseDto?> GetByIdAsync(int id)
        {
         Items? item = await _repo.GetByIdAsync(id); 
         if(item is null)
            {
                return null; 
            }
            return ToDto(item); 
        }

        private static ItemResponseDto ToDto(Items item)
        {
            ItemResponseDto dto = new ItemResponseDto();
            dto.Id = item.Id; 
            dto.Category_id = item.Category_id; 
            dto.Description = item.Description;
            dto.Image_url = item.Image_url; 
            dto.Name = item.Name;
            dto.Price = item.Price; 
            dto.Tag = item.Tag; 

            return dto; 
        }
    }
}