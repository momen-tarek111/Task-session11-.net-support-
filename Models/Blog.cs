using Project3.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        [Length(5,20,ErrorMessage ="the {0} must be between {1} and {2} ")]
        [Title]
        public string Title { get; set; }
        [Required]
        [Length(20, 200, ErrorMessage = "the {0} must be between {1} and {2} ")]
        public string Content { get; set; }
        [Required(ErrorMessage = " Please enter AuthorName")]
        [Length(1, 15, ErrorMessage = "the {0} must be between {1} and {2} ")]
        [AuthorName]
        public string AuthorName { get; set; }
        public bool available { get; set; }
        [Required]
        public int? CategoryId {  get; set; }
        [ForeignKey("CategoryId")]
        public Category? category { get; set; }
        public DateTime? datetime { get; set; }
        public int? coments { get; set; }
        public string? img { get; set; }
    }
}
