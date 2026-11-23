

using api.Dto;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repo; 
        public CategoryServices(ICategoryRepository repo)
        {
            _repo = repo; 
        }
        public async Task<CategoryResponseDto> CreateAsync(CategoryCreateDto dto)
        {
           Categories category = new Categories(); 
           category.Name = dto.Name; 

           Categories saved = await _repo.CreateAsync(category); 
           return ToDto(saved); 
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            List<Categories> categories = await _repo.GetAllAsync(); 
            return categories.Select(ToDto).ToList(); 
        }

        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
           Categories? category = await _repo.GetByIdAsync(id); 
           if(category is null)
            {
                return null; 
            }
            return ToDto(category); 
        }

        private static CategoryResponseDto ToDto(Categories category)
        {
            CategoryResponseDto dto = new CategoryResponseDto(); 
            dto.Id = category.Id; 
            dto.Name = category.Name; 

            return dto; 
        }
    }
}