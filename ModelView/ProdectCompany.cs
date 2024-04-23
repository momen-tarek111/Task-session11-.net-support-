using Project3.Models;

namespace Project3.ModelView
{
    public class ProdectCompany
    {
        public Product? product { get; set; }
        public List<Company> _company { get; set; }
        public ProdectCompany(List<Company> company) { 
            _company = company;
        }
        }
}
