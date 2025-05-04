using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceModels.Enums;

namespace EcommercModels
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
