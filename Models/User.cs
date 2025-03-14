using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public string? Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
        public string? PurchaseHistory { get; set; } // Store as JSON or a serialized object
    }
}