using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = 0;

        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
