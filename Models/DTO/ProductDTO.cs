using Project3.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models.DTO
{
    public class ProductDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "you must enter the name of product")]
        [DeniedValues("aaa", "AAA", ErrorMessage = "the name must be any value excipt AAA,aaa")]
        [Length(1, 10)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
       
        [Required]
        public int CompanyId { get; set; }
        public Company? company { get; set; }
    }
}
