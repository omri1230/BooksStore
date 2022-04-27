using BooksStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price 50")]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price 100")]
        public double Price100 { get; set; }
        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }
        [Display(Name = "Cover Type")]
        [ValidateNever]
        public CoverType CoverType { get; set; }
    }
}
