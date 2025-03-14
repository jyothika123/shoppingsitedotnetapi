using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Data;
using Microsoft.EntityFrameworkCore;
 
namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly MyDbContext _context;
 
        public CartItemController(MyDbContext context)
        {
            _context = context;
        }
 
        // GET: api/CartItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }
 
        // GET: api/CartItem/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
 
            if (cartItem == null)
            {
                return NotFound();
            }
 
            return cartItem;
        }
 
        // POST: api/CartItem
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
 
            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.Id }, cartItem);
        }
 
        // PUT: api/CartItem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }
 
            _context.Entry(cartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
 
        // DELETE: api/CartItem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
 
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
    }
}
 