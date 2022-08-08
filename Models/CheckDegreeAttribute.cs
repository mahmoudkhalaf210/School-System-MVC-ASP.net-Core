using System.ComponentModel.DataAnnotations;

namespace Day2.Models
{
    public class CheckDegreeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int degree = (int)value;

            if( degree >= 50 && degree <= 100 )
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Degree Must Be Between 50 and 100");
        }
    }
}
