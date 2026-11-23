

using api.Dto;

namespace api.Services
{
    public interface ICategoryServices
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task<CategoryResponseDto?> GetByIdAsync(int id); 
        Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto);
    }
}