using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Project3.Database;
using Project3.Models;
using Project3.ModelView;
using Project3.Utility;
using System.Globalization;
using System.IO.Pipes;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;
namespace Project3.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private static List<ProductController> products = new List<ProductController>();
        private static List<Company>_company = new List<Company>();

        private static List<Blog> blogs = new List<Blog>();
        private static List<Category> _category = new List<Category>();
        private readonly ApplicationDbContext _db;
        private static ProdectCompany modelView;
        private static BlogCategory blogcategory;

        public DashBoardController(ApplicationDbContext db)
        {
            _db = db;
            _company.Add(new Company{ Id=1,Name="Niki"});
            _company.Add(new Company { Id = 2, Name = "adidas" });
            _category.Add(new Category { Id = 1, Name="Tutorial" });
            _category.Add(new Category { Id = 2, Name = "News" });
            _category.Add(new Category { Id = 3, Name = "Business" });
            _category.Add(new Category { Id = 4, Name = "Fitness" });
            _category.Add(new Category { Id = 5, Name = "Sports" });
        }
        
        public IActionResult Index()
        {
            return View();
        }
        #region AddProduct
        [Authorize(Roles =RL.RoleAdmin)]
        public IActionResult AddProduct()
        {
            modelView = new ProdectCompany(_db.Companies.ToList());
            return View(modelView);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductController product)
        {
            if (!ModelState.IsValid)
            {
                modelView.product=product;
                return View(modelView);
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        #endregion
        #region PrintAllData
        [Authorize(Roles =RL.RoleEmployee)]
        public IActionResult ViewAllData()
        {
            return View(_db.Products.Include(p=>p.company).ToList());
        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            
            _db.Products.Remove(_db.Products.FirstOrDefault(x => x.Id == id));

            _db.SaveChanges();
            return RedirectToAction("ViewAllData");
        }
        #endregion
        #region EditProduct
        public IActionResult Edit(int id)

        {
            ProductController product = _db.Products.FirstOrDefault(p => p.Id == id);

            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(ProductController product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            ProductController pd = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            pd.Name = product.Name;
            pd.Description = product.Description;
            pd.Price = product.Price;
            pd.Quantity = product.Quantity;
            pd.EnableSize = product.EnableSize;
            pd.CompanyId = product.CompanyId;
            _db.Products.Update(pd);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        #endregion
        #region AddAndEdiitBlog
        public IActionResult AddBlog(int id = -1)
        {
            Blog blog = new Blog();
            blogcategory = new BlogCategory(_db.Categories.ToList());

            if (id == -1)
            {
                blog.category = new Category();
                blogcategory.blog=blog;
                return View(blogcategory);
            }
            else
            {
                blog = _db.Blogs.FirstOrDefault(p => p.Id == id);
                blogcategory.blog = blog;
                return View(blogcategory);
            }
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                blogcategory.blog = blog;
                return View(blogcategory);
            }
            Blog bl = _db.Blogs.FirstOrDefault(p => p.Id == blog.Id);
            if (bl != null)
            {
                bl.Title = blog.Title;
                bl.Content = blog.Content;
                bl.AuthorName = blog.AuthorName;
                bl.available = blog.available;
                bl.CategoryId = blog.CategoryId;
                _db.Blogs.Update(bl);
                _db.SaveChanges();
            }
            else
            {
              
                _db.Blogs.Add(blog);
                _db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        #endregion
        #region PrintAllBlogs
        public IActionResult ViewAllBlogs()
        {
            return View(_db.Blogs.Include(p => p.category).ToList());
        }
        #endregion
        #region DeleteBlog
        public IActionResult DeleteBlog(int id)
        {
            _db.Blogs.Remove(_db.Blogs.FirstOrDefault(x => x.Id == id));
            _db.SaveChanges();
            return RedirectToAction("ViewAllBlogs");
        }
        #endregion
        /*#region EditBlog
             public IActionResult EditBlog(int id)

             {
                 Blog blog = blogs.FirstOrDefault(p => p.Id == id);

                 return View(blog);

             }
             [HttpPost]
             public IActionResult EditBlog(Blog blog)

             {
                 Blog bl = blogs.FirstOrDefault(p => p.Id == blog.Id);

                 bl.Title = blog.Title;
                 bl.Content = blog.Content;
                 bl.AuthorName = blog.AuthorName;
                 bl.available = blog.available;
             if (bl.category.Id != blog.category.Id)
             {

                 if (blog.category.Id == 1)
                 {
                     bl.category.Name = "Tutorial";

                 }
                 else if (blog.category.Id == 2)
                 {
                     bl.category.Name = "News";
                 }
                 else if (blog.category.Id == 3)
                 {
                     bl.category.Name = "Business";

                 }
                 else if (blog.category.Id == 4)
                 {
                     bl.category.Name = "Fitness";

                 }
                 else if (blog.category.Id == 5)
                 {
                     bl.category.Name = "Sports";

                 }
             }
             bl.category.Id = blog.category.Id;
             return RedirectToAction("index");
             }
         #endregion*/
    }
}
