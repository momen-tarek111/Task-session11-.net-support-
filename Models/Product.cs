using Project3.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project3.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="you must enter the name of product")]
        [DeniedValues("aaa","AAA",ErrorMessage ="the name must be any value excipt AAA,aaa")]
        [Length(1,10)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [MaxPrice(3000)]
        public float Price { get; set; }
        public bool EnableSize { get; set; }
        public float OldPrice { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
