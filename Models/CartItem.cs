using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace MyWebAPI.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
 
        [Required]
        public int Quantity { get; set; }
 
        // Foreign Keys
        [ForeignKey("User")]
        public int UserId { get; set; }
 
        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}