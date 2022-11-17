using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Open/Closed Principle - InventoryController inherits from ControllerBase
    //Liskov Substitution Principle - InventoryController extends the functionality of its parent class ControllerBase without affecting its behavior
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        public InventoryController(InventoryDbContext context) => _context = context;

        //Single Responsibility Principle - the Get action only has one reason to change - in the event that a request is made to pull all list items.
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _context.Items.ToListAsync();
        }

        //Single Responsibility Principle - the Get action only has one reason to change - in the event that a request is made to pull a specific list item.
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        //Single Responsibility Principle - the Post action only has one reason to change - in the event that a request is made to add an item to the list.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        //Single Responsibility Principle - the Put action only has one reason to change - in the event that a request is made to update a specific list item.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Item item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Single Responsibility Principle - the Delete action only has one reason to change - in the event that a request is made to delete a specific list item.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = await _context.Items.FindAsync(id);
            if (itemToDelete == null) return NotFound();

            _context.Items.Remove(itemToDelete);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
