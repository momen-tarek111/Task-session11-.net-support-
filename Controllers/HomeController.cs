using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3.Database;
using Project3.Models;
using Project3.ModelView;
using System.Diagnostics;

namespace Project3.Controllers
{
    public class HomeController(ApplicationDbContext _db) : Controller
    {
        public List<ProductController> products { get; set; }
        public BlogsCategories blogsCategories= new BlogsCategories();
        public IActionResult Index()
        {
            products = _db.Products.Include(m => m.company).ToList();
            return View(products);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitForm(ContactForm contactForm)
        {
            if(!ModelState.IsValid)
            {
                return View("Contact", contactForm);
            }
            _db.ContactForm.Add(contactForm);
            return View("contact");
        }
        public IActionResult Blog()
        {
            blogsCategories.blogs = _db.Blogs.Include(m => m.category).ToList();
            blogsCategories.categories=_db.Categories.ToList();
            return View(blogsCategories);
        }


    }
}
