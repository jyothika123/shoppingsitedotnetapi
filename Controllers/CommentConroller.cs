using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CommentController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/Comment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        // PUT: api/Comment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest("Comment ID mismatch.");
            }

            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return NotFound("Comment not found.");
            }

            // Update only relevant fields
            existingComment.Text = comment.Text;
            existingComment.Rating = comment.Rating;
            existingComment.ImageUrl = comment.ImageUrl;
            existingComment.UserId = comment.UserId;
            existingComment.ProductId = comment.ProductId;

            _context.Entry(existingComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Comment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
