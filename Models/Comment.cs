using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Text { get; set; }

        public int Rating { get; set; } // Example: 1-5 stars

        public string? ImageUrl { get; set; }

        // Foreign Keys
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}