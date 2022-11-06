using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemDbContext _context;
        public ItemController(ItemDbContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _context.Items.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Item item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _context.Items.FindAsync(id);
            if (itemToDelete == null) return NotFound();

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
