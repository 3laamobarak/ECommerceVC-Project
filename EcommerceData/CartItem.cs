using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommercModels
{
    public class CartItem
    {

        [Key]
        public int CartItemID { get; set; }
        [Required]
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        [Required]
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}