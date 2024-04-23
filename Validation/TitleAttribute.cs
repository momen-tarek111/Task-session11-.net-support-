using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Project3.Validation
{
    public class TitleAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string _Title;
            if (value == null) {
                return new ValidationResult("Enter the Title of the Blog");
            }
            _Title = value.ToString();
            var regex = new Regex(@"^[a-zA-Z0-9][a-zA-Z0-9 ]*[a-zA-Z0-9]$");
            if (!regex.IsMatch(_Title))
            {
                return new ValidationResult("The Title should be characters only and may be contain numbers");
            }
            return ValidationResult.Success;
        }
    }
}
