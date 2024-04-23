using Project3.Models;
using System.ComponentModel.DataAnnotations;

namespace Project3.Util
{
    public class MaxPriceForCompanyAttribute : ValidationAttribute
    {
        private readonly int _maxPrice;
        public MaxPriceForCompanyAttribute(int maxPrice) 
        {
            _maxPrice = maxPrice;
        }

        protected override ValidationResult? IsValid(Object value, ValidationContext validationContext)
        {
            Product p = (Product) validationContext.ObjectInstance;

            int price;

            if(!int.TryParse(value.ToString(), out price))
            {
                return new ValidationResult("enter int value");
            }

            if(p.CompanyId == 1 && price > _maxPrice)
            {
                return new ValidationResult("adidas price less then " + _maxPrice.ToString());
            }
            return ValidationResult.Success;

        }

    }

}
