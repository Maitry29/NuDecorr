﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrbanNest.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
