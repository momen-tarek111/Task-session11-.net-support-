using Project3.Models;
using System.Reflection.Metadata;

namespace Project3.ModelView
{
    public class BlogCategory
    {
        public Blog? blog { get; set;}
        public List<Category> categories { get; set; }
        public BlogCategory(List<Category>c) {

            categories = c;
        }
    }
}
