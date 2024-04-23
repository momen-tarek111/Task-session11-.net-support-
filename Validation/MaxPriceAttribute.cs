using Project3.Models;
using System.ComponentModel.DataAnnotations;

namespace Project3.Validation
{
    public class MaxPriceAttribute:ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceAttribute(int price ) { 
            _maxPrice = price;
            
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Product product=(Product) validationContext.ObjectInstance;
            int price;
            if(!int.TryParse(value.ToString(),out price))
            {
                return new ValidationResult("enter int value");
            }
            if (product.CompanyId == 2 && price > _maxPrice)
            {
                return new ValidationResult("adidas price less than "+_maxPrice.ToString());
            }
            return ValidationResult.Success;
            
        }
    }
}
