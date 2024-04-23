using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Database;
using Project3.Models;

namespace Project3.Pages.Companies
{
    public class CreateCompanyModel(ApplicationDbContext _db) : PageModel

    {
        [BindProperty]
        public Company company {  get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost() { 
        
            _db.Companies.Add(company);
            _db.SaveChanges();
            return RedirectToPage("index");
        }
    }
}
