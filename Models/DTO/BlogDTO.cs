using System.ComponentModel.DataAnnotations;

namespace Project3.Models.DTO
{
    public class BlogDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Length(5, 20, ErrorMessage = "the {0} must be between {1} and {2} ")]
        
        public string Title { get; set; }
        [Required]
        [Length(20, 200, ErrorMessage = "the {0} must be between {1} and {2} ")]
        public string Content { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        
        public Category? category { get; set; }
    }
}
