
using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
       private readonly ICategoryServices _services; 
       public CategoryController(ICategoryServices services)
        {
            _services = services; 
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync()); 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
        {
            CategoryResponseDto? found = await _services.GetByIdAsync(id); 
            if(found is null)
            {
                return NotFound($"Category with the id {id} could not be found"); 
            }
            return Ok(found); 
        }
        [HttpPost("create")]
        public async Task<ActionResult<CategoryResponseDto>> Create([FromBody] CategoryCreateDto dto)
        {
            CategoryResponseDto category = await _services.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = category.Id}, category); 
        }
    }
}