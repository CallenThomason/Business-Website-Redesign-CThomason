

using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ItemRepository : IItemsRepository
    {

        private readonly AppDbContext _db; 
        public ItemRepository(AppDbContext db)
        {
            _db = db; 
        }
        public async Task<Items> AddAsync(Items item)
        {
          _db.Items.Add(item);
          await _db.SaveChangesAsync(); 
          return item; 
        }

        public async Task<List<Items>> GetAllAsync()
        {
             return await _db.Items.ToListAsync();
        }

        public async Task<Items?> GetByIdAsync(int id)
        {
             return await _db.Items.FindAsync(id); 
        }
    }
}