using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Database;
using Project3.Models;

namespace Project3.Pages.Companies
{
    public class EditCompanyModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company company { get; set; }
        public void OnGet(int id)
        {
            company = _db.Companies.FirstOrDefault(m => m.Id == id);
        }
        public IActionResult OnPost(int id)
        {
            var c=_db.Companies.FirstOrDefault(c => c.Id == company.Id);
            c.Name= company.Name;
            _db.SaveChanges();
            return RedirectToPage("ViewCompany");
        }
    }
}
