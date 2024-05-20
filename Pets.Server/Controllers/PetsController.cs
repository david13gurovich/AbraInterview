using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pets.Server.Entities;
using Pets.Server.Services;

namespace Pets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly PetService _petService;
        public PetsController(PetService petService) =>
            _petService = petService;


        [HttpGet]
        public async Task<IEnumerable<Pet>> Get() =>
            await _petService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet?>> GetById(string id)
        {
            var item = await _petService.GetByIdAsync(id);
            return item is not null ? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string name, [FromForm] string created_at, [FromForm] string type, [FromForm] string color, [FromForm] int age )
        {
            var pet = await _petService.CreateAsync(name, created_at, type, color, age);
            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        
    }
}
