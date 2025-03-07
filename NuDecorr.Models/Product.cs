using NuDecorr.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductID { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    public int CategoryID { get; set; } // Foreign Key

    
    [StringLength(500)]
    public string ImageURL { get; set; }

   

    // Navigation Property
    [ForeignKey("CategoryID")]
    public virtual Category Category { get; set; }
}
