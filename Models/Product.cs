using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal ShippingCost { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}