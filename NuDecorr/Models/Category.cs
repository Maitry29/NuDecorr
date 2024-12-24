using System.ComponentModel.DataAnnotations;

namespace NuDecorr.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
    }
}
