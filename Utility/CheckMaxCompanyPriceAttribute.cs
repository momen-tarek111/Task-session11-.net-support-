using Project3.Models;
using System.ComponentModel.DataAnnotations;

namespace Project3.Utility
{
    public class CheckMaxCompanyPriceAttribute : ValidationAttribute
    {
        private readonly int _maxCompanyPrice;
        public CheckMaxCompanyPriceAttribute(int price) {
            _maxCompanyPrice = price;
        }

        protected override ValidationResult? IsValid(Object value , ValidationContext validationContext)
        {
            Product product = (Product)validationContext.ObjectInstance;

            int price;

            if (!int.TryParse(value.ToString(), out price))
            {
                return new ValidationResult("Invalid price value.");
            }

            if (product.CompanyId == 1 && price > _maxCompanyPrice)
            {
                return new ValidationResult("Price must be less than 30000 for adidas.");
            }

            return ValidationResult.Success;
        }
    }
}
