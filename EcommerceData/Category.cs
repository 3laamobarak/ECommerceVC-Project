﻿using System.ComponentModel.DataAnnotations;

namespace EcommercModels
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required, MaxLength(100)] 
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}