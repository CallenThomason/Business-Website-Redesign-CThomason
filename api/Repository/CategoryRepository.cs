

using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db; 
        public CategoryRepository(AppDbContext db)
        {
            _db = db; 
        }
        public async Task<Categories> CreateAsync(Categories category)
        {
          _db.Categories.Add(category);
          await _db.SaveChangesAsync(); 
          return category;  
        }

        public async Task<List<Categories>> GetAllAsync()
        {
          return await _db.Categories.ToListAsync(); 
        }

        public async Task<Categories?> GetByIdAsync(int id)
        {
           return await _db.Categories.FindAsync(id); 
        }
    }
}