
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _db;

        public RestaurantRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {

            _db.Restaurants.Add(restaurant);
            await _db.SaveChangesAsync();
            return restaurant;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _db.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _db.Restaurants.FindAsync(id);
        }
    }
}