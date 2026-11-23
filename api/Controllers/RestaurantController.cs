

using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _services; 
        public RestaurantController(IRestaurantServices services)
        {
            _services = services; 
        }
        [HttpGet]
        public async Task<ActionResult<List<RestuarantResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync()); 
        }
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<RestuarantResponseDto>> GetById(int id)
        {
            RestuarantResponseDto? restaurant = await _services.GetByIdAsync(id); 
            if(restaurant is null)
            {
                return NotFound($"No Restaurant with {id} exists");

            }
            return Ok(restaurant); 
        }
        [HttpPost("create")]
        public async Task<ActionResult<RestuarantResponseDto>> Create([FromBody] RestuarantCreateDto dto)
        {
            RestuarantResponseDto restaurant = await _services.CreateAsync(dto); 

            return CreatedAtAction(nameof(GetById), new {id = restaurant.Id}, restaurant);
        }
    }
}