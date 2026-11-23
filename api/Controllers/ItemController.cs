
using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices _services; 
        public ItemController(IItemServices services)
        {
            _services = services; 
        }
        [HttpGet]
        public async Task<ActionResult<List<ItemResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync()); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponseDto>> GetById(int id)
        {
            ItemResponseDto? item = await _services.GetByIdAsync(id); 
            if(item is null)
            {
                return NotFound($"No Item with the id {id} exists"); 

            }
            return Ok(item); 
        }
        [HttpPost("create")]
        public async Task<ActionResult<ItemResponseDto>> AddItem([FromBody] ItemCreateDto dto)
        {
            ItemResponseDto item = await _services.AddItemAsync(dto); 
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item); 
        }
    }

  
}