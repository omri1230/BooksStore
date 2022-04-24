using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Cover Type")]
        [Required]
        public string Name { get; set; }
    }
}
