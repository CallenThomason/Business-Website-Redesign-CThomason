using api.Models; 

namespace api.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Categories>> GetAllAsync(); 
        Task<Categories?> GetByIdAsync(int id); 
        Task<Categories> CreateAsync(Categories category); 

    }
}