

using api.Dto;

namespace api.Services
{
    public interface IRestaurantServices
    {
        Task<List<RestuarantResponseDto>> GetAllAsync();
        Task<RestuarantResponseDto?> GetByIdAsync(int id);
        Task<RestuarantResponseDto> CreateAsync(RestuarantCreateDto dto); 
    }
}