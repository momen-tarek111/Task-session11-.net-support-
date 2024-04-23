using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Project3.Validation
{
    public class AuthorNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string _AuthorName;
            if (value == null)
            {
                return new ValidationResult("you must enter Author Name");

            }
            _AuthorName = value.ToString();
            var regex = new Regex(@"^[a-zA-Z][a-zA-Z ]*[a-zA-Z]$");
            if (!regex.IsMatch(_AuthorName))
            {
                return new ValidationResult("The name Must be characters only ");
            }
            return ValidationResult.Success;
    }
        
           
    }
 }
