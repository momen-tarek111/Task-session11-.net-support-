using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Database;
using Project3.Models;

namespace Project3.Pages.Companies
{
    public class ViewCompanyModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public List<Company> companies { get; set; }
        public void OnGet()
        {
            companies = _db.Companies.ToList();
        }

        public IActionResult OnPostDelete(int id) {
            var company=_db.Companies.SingleOrDefault(x => x.Id == id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
            return RedirectToPage("ViewCompany");
        }
    }
}
