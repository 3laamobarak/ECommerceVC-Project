using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceModels.Enums;
namespace EcommercModels

{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public DateTime? DateProcessed { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}