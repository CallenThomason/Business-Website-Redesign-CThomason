

using api.Dto;

using api.Models;
using api.Repository;

namespace api.Services
{
    public class RestuarantServices : IRestaurantServices
    {
        private readonly IRestaurantRepository _repo; 
        public RestuarantServices(IRestaurantRepository repo)
        {
            _repo = repo; 
        }
        public async Task<RestuarantResponseDto> CreateAsync(RestuarantCreateDto dto)
        {
          Restaurant restaurant = new Restaurant(); 
          restaurant.Name = dto.Name; 
          restaurant.Tagline = dto.Tagline; 
          restaurant.Address = dto.Address; 
          restaurant.Hours = dto.Hours; 
          restaurant.Phone = dto.Phone; 

          Restaurant saved = await _repo.AddAsync(restaurant); 
          return ToDto(saved); 
        }

        public async Task<List<RestuarantResponseDto>> GetAllAsync()
        {
           List<Restaurant> restaurants = await _repo.GetAllAsync();
           return restaurants.Select(ToDto).ToList();  
        }

        public async Task<RestuarantResponseDto?> GetByIdAsync(int id)
        {
            Restaurant? restaurant = await _repo.GetByIdAsync(id); 
            if(restaurant is null)
            {
                return null; 
            }
            return ToDto(restaurant); 
        }

        private static RestuarantResponseDto ToDto(Restaurant restaurant)
        {
            RestuarantResponseDto dto = new RestuarantResponseDto(); 
            dto.Id = restaurant.Id; 
            dto.Name = restaurant.Name; 
            dto.Tagline = restaurant.Tagline; 
            dto.Address = restaurant.Address; 
            dto.Hours = restaurant.Hours; 
            dto.Phone = restaurant.Phone; 

            return dto; 
        
        }
    }
}